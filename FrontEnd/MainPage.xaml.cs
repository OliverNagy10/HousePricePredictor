﻿using System.Text;
using Microcharts;
using SkiaSharp;

namespace HousePricePredictorUK
{
    public partial class MainPage : ContentPage
    {
        private const string ApiUrl = "http://192.168.1.5:5000/predict"; //API endpoint
        private List<string> townCityList = new List<string>
{
   "ABBOTS LANGLEY",
"ABERAERON",
"ABERDARE",
"ABERDOVEY",
"ABERGAVENNY",
"ABERGELE",
"ABERTILLERY",
"ABERYSTWYTH",
"ABINGDON",
"ACCRINGTON",
"ADDLESTONE",
"ALCESTER",
"ALDEBURGH",
"ALDERLEY EDGE",
"ALDERSHOT",
"ALFORD",
"ALFRETON",
"ALNWICK",
"ALRESFORD",
"ALSTON",
"ALTON",
"ALTRINCHAM",
"AMBLESIDE",
"AMERSHAM",
"AMLWCH",
"AMMANFORD",
"ANDOVER",
"APPLEBY-IN-WESTMORLAND",
"ARLESEY",
"ARTHOG",
"ARUNDEL",
"ASCOT",
"ASHBOURNE",
"ASHBY-DE-LA-ZOUCH",
"ASHFORD",
"ASHINGTON",
"ASHTEAD",
"ASHTON-UNDER-LYNE",
"ASKAM-IN-FURNESS",
"ATHERSTONE",
"ATTLEBOROUGH",
"AXBRIDGE",
"AXMINSTER",
"AYLESBURY",
"AYLESFORD",
"BACUP",
"BADMINTON",
"BAGILLT",
"BAGSHOT",
"BAKEWELL",
"BALA",
"BALDOCK",
"BAMBURGH",
"BAMPTON",
"BANBURY",
"BANGOR",
"BANSTEAD",
"BANWELL",
"BARGOED",
"BARKING",
"BARMOUTH",
"BARNARD CASTLE",
"BARNET",
"BARNETBY",
"BARNOLDSWICK",
"BARNSLEY",
"BARNSTAPLE",
"BARROW-IN-FURNESS",
"BARROW-UPON-HUMBER",
"BARRY",
"BARTON-UPON-HUMBER",
"BASILDON",
"BASINGSTOKE",
"BATH",
"BATLEY",
"BATTLE",
"BEACONSFIELD",
"BEAMINSTER",
"BEAUMARIS",
"BEAWORTHY",
"BECCLES",
"BECKENHAM",
"BECKERMET",
"BEDALE",
"BEDFORD",
"BEDLINGTON",
"BEDWORTH",
"BELFORD",
"BELPER",
"BELVEDERE",
"BEMBRIDGE",
"BENFLEET",
"BERKELEY",
"BERKHAMSTED",
"BERWICK-UPON-TWEED",
"BETCHWORTH",
"BETWS-Y-COED",
"BEVERLEY",
"BEWDLEY",
"BEXHILL-ON-SEA",
"BEXLEY",
"BEXLEYHEATH",
"BICESTER",
"BIDEFORD",
"BIGGLESWADE",
"BILLERICAY",
"BILLINGHAM",
"BILLINGHURST",
"BILLINGSHURST",
"BILSTON",
"BINGLEY",
"BIRCHINGTON",
"BIRKENHEAD",
"BIRMINGHAM",
"BISHOP AUCKLAND",
"BISHOPS CASTLE",
"BISHOP'S STORTFORD",
"BLACKBURN",
"BLACKPOOL",
"BLACKWOOD",
"BLAENAU FFESTINIOG",
"BLAKENEY",
"BLANDFORD FORUM",
"BLAYDON-ON-TYNE",
"BLYTH",
"BODMIN",
"BODORGAN",
"BOGNOR REGIS",
"BOLDON COLLIERY",
"BOLTON",
"BONCATH",
"BOOTLE",
"BORDON",
"BOREHAMWOOD",
"BORTH",
"BOSCASTLE",
"BOSTON",
"BOURNE",
"BOURNE END",
"BOURNEMOUTH",
"BOW STREET",
"BRACKLEY",
"BRACKNELL",
"BRADFORD",
"BRADFORD-ON-AVON",
"BRAINTREE",
"BRAMPTON",
"BRANDON",
"BRAUNTON",
"BRECON",
"BRENTFORD",
"BRENTWOOD",
"BRIDGEND",
"BRIDGNORTH",
"BRIDGWATER",
"BRIDLINGTON",
"BRIDPORT",
"BRIERLEY HILL",
"BRIGG",
"BRIGHOUSE",
"BRIGHTON",
"BRISTOL",
"BRIXHAM",
"BROADSTAIRS",
"BROADSTONE",
"BROADWAY",
"BROCKENHURST",
"BROMLEY",
"BROMSGROVE",
"BROMYARD",
"BROSELEY",
"BROUGH",
"BROUGHTON-IN-FURNESS",
"BROXBOURNE",
"BRUTON",
"BRYNTEG",
"BUCKFASTLEIGH",
"BUCKHURST HILL",
"BUCKINGHAM",
"BUCKLEY",
"BUCKNELL",
"BUDE",
"BUDLEIGH SALTERTON",
"BUILTH WELLS",
"BUNGAY",
"BUNTINGFORD",
"BURES",
"BURFORD",
"BURGESS HILL",
"BURNHAM-ON-CROUCH",
"BURNHAM-ON-SEA",
"BURNLEY",
"BURNTWOOD",
"BURRY PORT",
"BURTON-ON-TRENT",
"BURY",
"BURY ST EDMUNDS",
"BURY ST. EDMUNDS",
"BUSHEY",
"BUXTON",
"CAERNARFON",
"CAERPHILLY",
"CAERSWS",
"CALDICOT",
"CALLINGTON",
"CALNE",
"CALSTOCK",
"CAMBERLEY",
"CAMBORNE",
"CAMBRIDGE",
"CAMELFORD",
"CANNOCK",
"CANTERBURY",
"CANVEY ISLAND",
"CARDIFF",
"CARDIGAN",
"CARLISLE",
"CARMARTHEN",
"CARNFORTH",
"CARSHALTON",
"CARTERTON",
"CASTLE CARY",
"CASTLEFORD",
"CATERHAM",
"CATTERICK GARRISON",
"CEMAES BAY",
"CHALFONT ST GILES",
"CHALFONT ST. GILES",
"CHARD",
"CHATHAM",
"CHATHILL",
"CHATTERIS",
"CHEADLE",
"CHEDDAR",
"CHELMSFORD",
"CHELTENHAM",
"CHEPSTOW",
"CHERTSEY",
"CHESHAM",
"CHESSINGTON",
"CHESTER",
"CHESTER LE STREET",
"CHESTERFIELD",
"CHICHESTER",
"CHIGWELL",
"CHINNOR",
"CHIPPENHAM",
"CHIPPING CAMPDEN",
"CHIPPING NORTON",
"CHISLEHURST",
"CHOPPINGTON",
"CHORLEY",
"CHRISTCHURCH",
"CHULMLEIGH",
"CHURCH STRETTON",
"CINDERFORD",
"CIRENCESTER",
"CLACTON-ON-SEA",
"CLARBESTON ROAD",
"CLEATOR",
"CLEATOR MOOR",
"CLECKHEATON",
"CLEETHORPES",
"CLEVEDON",
"CLITHEROE",
"CLYNDERWEN",
"COALVILLE",
"COBHAM",
"COCKERMOUTH",
"COLCHESTER",
"COLEFORD",
"COLNE",
"COLWYN BAY",
"COLYTON",
"CONGLETON",
"CONISTON",
"CONSETT",
"CONWY",
"CORBRIDGE",
"CORBY",
"CORNHILL-ON-TWEED",
"CORSHAM",
"CORWEN",
"COTTINGHAM",
"COULSDON",
"COVENTRY",
"COWBRIDGE",
"COWES",
"CRADLEY HEATH",
"CRAMLINGTON",
"CRANBROOK",
"CRANLEIGH",
"CRAVEN ARMS",
"CRAWLEY",
"CREDITON",
"CREWE",
"CREWKERNE",
"CRICCIETH",
"CRICKHOWELL",
"CROMER",
"CROOK",
"CROWBOROUGH",
"CROWTHORNE",
"CROYDON",
"CRYMYCH",
"CULLOMPTON",
"CWMBRAN",
"DAGENHAM",
"DALTON-IN-FURNESS",
"DARLINGTON",
"DARTFORD",
"DARTMOUTH",
"DARWEN",
"DAVENTRY",
"DAWLISH",
"DEAL",
"DEESIDE",
"DELABOLE",
"DENBIGH",
"DERBY",
"DEREHAM",
"DEVIZES",
"DEWSBURY",
"DIDCOT",
"DINAS POWYS",
"DISS",
"DOLGELLAU",
"DOLWYDDELAN",
"DONCASTER",
"DORCHESTER",
"DORKING",
"DOVER",
"DOWNHAM MARKET",
"DRIFFIELD",
"DROITWICH",
"DRONFIELD",
"DRYBROOK",
"DUDLEY",
"DUKINFIELD",
"DULAS",
"DULVERTON",
"DUNMOW",
"DUNSTABLE",
"DURHAM",
"DURSLEY",
"DYFFRYN ARDUDWY",
"DYMOCK",
"EAST BOLDON",
"EAST COWES",
"EAST GRINSTEAD",
"EAST MOLESEY",
"EASTBOURNE",
"EASTLEIGH",
"EBBW VALE",
"EDENBRIDGE",
"EDGWARE",
"EGHAM",
"EGREMONT",
"ELLAND",
"ELLESMERE",
"ELLESMERE PORT",
"ELY",
"EMSWORTH",
"ENFIELD",
"EPPING",
"EPSOM",
"ERITH",
"ESHER",
"ETCHINGHAM",
"EVESHAM",
"EXETER",
"EXMOUTH",
"EYE",
"FAIRBOURNE",
"FAIRFORD",
"FAKENHAM",
"FALMOUTH",
"FAREHAM",
"FARINGDON",
"FARNBOROUGH",
"FARNHAM",
"FAVERSHAM",
"FELIXSTOWE",
"FELTHAM",
"FERNDALE",
"FERNDOWN",
"FERRYHILL",
"FERRYSIDE",
"FILEY",
"FISHGUARD",
"FLEET",
"FLEETWOOD",
"FLINT",
"FOLKESTONE",
"FORDINGBRIDGE",
"FOREST ROW",
"FOWEY",
"FRESHWATER",
"FRINTON-ON-SEA",
"FRIZINGTON",
"FRODSHAM",
"FROME",
"GAERWEN",
"GAINSBOROUGH",
"GARNDOLBENMAEN",
"GATESHEAD",
"GERRARDS CROSS",
"GILLINGHAM",
"GLASTONBURY",
"GLOGUE",
"GLOSSOP",
"GLOUCESTER",
"GODALMING",
"GODSTONE",
"GOODWICK",
"GOOLE",
"GOSPORT",
"GRANGE-OVER-SANDS",
"GRANTHAM",
"GRAVESEND",
"GRAYS",
"GREAT MISSENDEN",
"GREAT YARMOUTH",
"GREENFORD",
"GREENHITHE",
"GRETNA",
"GRIMSBY",
"GUILDFORD",
"GUISBOROUGH",
"GUNNISLAKE",
"HAILSHAM",
"HALESOWEN",
"HALESWORTH",
"HALIFAX",
"HALSTEAD",
"HALTWHISTLE",
"HAMPTON",
"HARLECH",
"HARLESTON",
"HARLOW",
"HARPENDEN",
"HARROGATE",
"HARROW",
"HARTFIELD",
"HARTLEPOOL",
"HARWICH",
"HASLEMERE",
"HASSOCKS",
"HASTINGS",
"HATFIELD",
"HAVANT",
"HAVERFORDWEST",
"HAVERHILL",
"HAWES",
"HAYES",
"HAYLE",
"HAYLING ISLAND",
"HAYWARDS HEATH",
"HEANOR",
"HEATHFIELD",
"HEBBURN",
"HEBDEN BRIDGE",
"HECKMONDWIKE",
"HELSTON",
"HEMEL HEMPSTEAD",
"HENFIELD",
"HENGOED",
"HENLEY-IN-ARDEN",
"HENLEY-ON-THAMES",
"HENLOW",
"HEREFORD",
"HERNE BAY",
"HERTFORD",
"HESSLE",
"HEXHAM",
"HEYWOOD",
"HIGH PEAK",
"HIGH WYCOMBE",
"HIGHBRIDGE",
"HINCKLEY",
"HINDHEAD",
"HINTON ST GEORGE",
"HINTON ST. GEORGE",
"HITCHIN",
"HOCKLEY",
"HODDESDON",
"HOLMFIRTH",
"HOLMROOK",
"HOLSWORTHY",
"HOLT",
"HOLYHEAD",
"HOLYWELL",
"HONITON",
"HOOK",
"HOPE VALLEY",
"HORLEY",
"HORNCASTLE",
"HORNCHURCH",
"HORNSEA",
"HORSHAM",
"HOUGHTON LE SPRING",
"HOUNSLOW",
"HOVE",
"HUDDERSFIELD",
"HULL",
"HUNGERFORD",
"HUNSTANTON",
"HUNTINGDON",
"HYDE",
"HYTHE",
"IBSTOCK",
"ILFORD",
"ILFRACOMBE",
"ILKESTON",
"ILKLEY",
"ILMINSTER",
"IMMINGHAM",
"INGATESTONE",
"IPSWICH",
"ISLES OF SCILLY",
"ISLEWORTH",
"IVER",
"IVYBRIDGE",
"JARROW",
"KEIGHLEY",
"KENDAL",
"KENILWORTH",
"KENLEY",
"KESTON",
"KESWICK",
"KETTERING",
"KIDDERMINSTER",
"KIDLINGTON",
"KIDWELLY",
"KILGETTY",
"KINGS LANGLEY",
"KING'S LYNN",
"KINGSBRIDGE",
"KINGSTON UPON THAMES",
"KINGSWINFORD",
"KINGTON",
"KIRKBY STEPHEN",
"KIRKBY-IN-FURNESS",
"KNARESBOROUGH",
"KNEBWORTH",
"KNIGHTON",
"KNOTTINGLEY",
"KNUTSFORD",
"LAMPETER",
"LANCASTER",
"LANCING",
"LANGPORT",
"LAUNCESTON",
"LEAMINGTON SPA",
"LEATHERHEAD",
"LECHLADE",
"LEDBURY",
"LEEDS",
"LEEK",
"LEE-ON-THE-SOLENT",
"LEICESTER",
"LEIGH",
"LEIGH-ON-SEA",
"LEIGHTON BUZZARD",
"LEISTON",
"LEOMINSTER",
"LETCHWORTH GARDEN CITY",
"LEWES",
"LEYBURN",
"LEYLAND",
"LICHFIELD",
"LIFTON",
"LIGHTWATER",
"LINCOLN",
"LINGFIELD",
"LIPHOOK",
"LISKEARD",
"LISS",
"LITTLEBOROUGH",
"LITTLEHAMPTON",
"LIVERPOOL",
"LIVERSEDGE",
"LLANARTH",
"LLANBEDR",
"LLANBEDRGOCH",
"LLANBRYNMAIR",
"LLANDEILO",
"LLANDINAM",
"LLANDOVERY",
"LLANDRINDOD WELLS",
"LLANDUDNO",
"LLANDUDNO JUNCTION",
"LLANDYSUL",
"LLANELLI",
"LLANERCHYMEDD",
"LLANFAIRFECHAN",
"LLANFAIRPWLLGWYNGYLL",
"LLANFECHAIN",
"LLANFYLLIN",
"LLANFYRNACH",
"LLANGADOG",
"LLANGAMMARCH WELLS",
"LLANGEFNI",
"LLANGOLLEN",
"LLANIDLOES",
"LLANNERCH-Y-MEDD",
"LLANON",
"LLANRHYSTUD",
"LLANRHYSTYD",
"LLANRWST",
"LLANSANFFRAID",
"LLANSANTFFRAID",
"LLANTWIT MAJOR",
"LLANWRDA",
"LLANWRTYD WELLS",
"LLANYBYDDER",
"LLANYMYNECH",
"LLWYNGWRIL",
"LONDON",
"LONGFIELD",
"LONGHOPE",
"LOOE",
"LOSTWITHIEL",
"LOUGHBOROUGH",
"LOUGHTON",
"LOUTH",
"LOWESTOFT",
"LUDLOW",
"LUTON",
"LUTTERWORTH",
"LYDBROOK",
"LYDBURY NORTH",
"LYDNEY",
"LYME REGIS",
"LYMINGTON",
"LYMM",
"LYNDHURST",
"LYNMOUTH",
"LYNTON",
"LYTHAM ST ANNES",
"LYTHAM ST. ANNES",
"MABLETHORPE",
"MACCLESFIELD",
"MACHYNLLETH",
"MAESTEG",
"MAIDENHEAD",
"MAIDSTONE",
"MALDON",
"MALMESBURY",
"MALPAS",
"MALTON",
"MALVERN",
"MANCHESTER",
"MANNINGTREE",
"MANSFIELD",
"MARAZION",
"MARCH",
"MARGATE",
"MARIANGLAS",
"MARKET DRAYTON",
"MARKET HARBOROUGH",
"MARKET RASEN",
"MARKFIELD",
"MARLBOROUGH",
"MARLOW",
"MARTOCK",
"MARYPORT",
"MATLOCK",
"MAYFIELD",
"MEIFOD",
"MELKSHAM",
"MELTON CONSTABLE",
"MELTON MOWBRAY",
"MENAI BRIDGE",
"MERRIOTT",
"MERTHYR TYDFIL",
"MEXBOROUGH",
"MIDDLESBROUGH",
"MIDDLEWICH",
"MIDHURST",
"MILFORD HAVEN",
"MILLOM",
"MILNTHORPE",
"MILTON KEYNES",
"MINDRUM",
"MINEHEAD",
"MIRFIELD",
"MITCHAM",
"MITCHELDEAN",
"MOELFRE",
"MOLD",
"MONMOUTH",
"MONTACUTE",
"MONTGOMERY",
"MOOR ROW",
"MORDEN",
"MORECAMBE",
"MORETON-IN-MARSH",
"MORPETH",
"MOUNTAIN ASH",
"MUCH HADHAM",
"MUCH WENLOCK",
"NANTWICH",
"NARBERTH",
"NEATH",
"NELSON",
"NESTON",
"NEW MALDEN",
"NEW MILTON",
"NEW QUAY",
"NEW ROMNEY",
"NEW TREDEGAR",
"NEWARK",
"NEWBIGGIN-BY-THE-SEA",
"NEWBURY",
"NEWCASTLE",
"NEWCASTLE EMLYN",
"NEWCASTLE UPON TYNE",
"NEWCASTLETON",
"NEWENT",
"NEWHAVEN",
"NEWMARKET",
"NEWNHAM",
"NEWPORT",
"NEWPORT PAGNELL",
"NEWQUAY",
"NEWTON ABBOT",
"NEWTON AYCLIFFE",
"NEWTON-LE-WILLOWS",
"NEWTOWN",
"NORMANTON",
"NORTH FERRIBY",
"NORTH SHIELDS",
"NORTH TAWTON",
"NORTH WALSHAM",
"NORTHALLERTON",
"NORTHAMPTON",
"NORTHOLT",
"NORTHWICH",
"NORTHWOOD",
"NORWICH",
"NOTTINGHAM",
"NUNEATON",
"OAKHAM",
"OKEHAMPTON",
"OLDBURY",
"OLDHAM",
"OLNEY",
"ONGAR",
"ORMSKIRK",
"ORPINGTON",
"OSSETT",
"OSWESTRY",
"OTLEY",
"OTTERY ST MARY",
"OTTERY ST. MARY",
"OXFORD",
"OXTED",
"PADSTOW",
"PAIGNTON",
"PAR",
"PEACEHAVEN",
"PEMBROKE",
"PEMBROKE DOCK",
"PENARTH",
"PENCADER",
"PENMAENMAWR",
"PENRHYNDEUDRAETH",
"PENRITH",
"PENRYN",
"PENTRAETH",
"PENTRE",
"PENYSARN",
"PENZANCE",
"PERRANPORTH",
"PERSHORE",
"PETERBOROUGH",
"PETERLEE",
"PETERSFIELD",
"PETWORTH",
"PEVENSEY",
"PEWSEY",
"PICKERING",
"PINNER",
"PLYMOUTH",
"POLEGATE",
"PONTEFRACT",
"PONTYCLUN",
"PONTYPOOL",
"PONTYPRIDD",
"POOLE",
"PORT ISAAC",
"PORT TALBOT",
"PORTH",
"PORTHCAWL",
"PORTHMADOG",
"PORTLAND",
"PORTSMOUTH",
"POTTERS BAR",
"POULTON-LE-FYLDE",
"PRENTON",
"PRESCOT",
"PRESTATYN",
"PRESTEIGNE",
"PRESTON",
"PRINCES RISBOROUGH",
"PRUDHOE",
"PUDSEY",
"PULBOROUGH",
"PURFLEET",
"PURFLEET-ON-THAMES",
"PURLEY",
"PWLLHELI",
"QUEENBOROUGH",
"RADLETT",
"RADSTOCK",
"RAINHAM",
"RAMSGATE",
"RAVENGLASS",
"RAYLEIGH",
"READING",
"REDCAR",
"REDDITCH",
"REDHILL",
"REDRUTH",
"REIGATE",
"RETFORD",
"RHAYADER",
"RHOSGOCH",
"RHOSNEIGR",
"RHYL",
"RICHMOND",
"RICKMANSWORTH",
"RIDING MILL",
"RINGWOOD",
"RIPLEY",
"RIPON",
"ROBERTSBRIDGE",
"ROCHDALE",
"ROCHESTER",
"ROCHFORD",
"ROMFORD",
"ROMNEY MARSH",
"ROMSEY",
"ROSSENDALE",
"ROSS-ON-WYE",
"ROTHERHAM",
"ROWLAND'S CASTLE",
"ROWLANDS GILL",
"ROWLEY REGIS",
"ROYSTON",
"RUARDEAN",
"RUGBY",
"RUGELEY",
"RUISLIP",
"RUNCORN",
"RUSHDEN",
"RUTHIN",
"RYDE",
"RYE",
"RYTON",
"SAFFRON WALDEN",
"SALCOMBE",
"SALE",
"SALFORD",
"SALISBURY",
"SALTASH",
"SALTBURN-BY-THE-SEA",
"SANDBACH",
"SANDHURST",
"SANDOWN",
"SANDWICH",
"SANDY",
"SAUNDERSFOOT",
"SAWBRIDGEWORTH",
"SAXMUNDHAM",
"SCARBOROUGH",
"SCUNTHORPE",
"SEAFORD",
"SEAHAM",
"SEAHOUSES",
"SEASCALE",
"SEATON",
"SEAVIEW",
"SEDBERGH",
"SELBY",
"SETTLE",
"SEVENOAKS",
"SHAFTESBURY",
"SHANKLIN",
"SHEERNESS",
"SHEFFIELD",
"SHEFFORD",
"SHEPPERTON",
"SHEPTON MALLET",
"SHERBORNE",
"SHERINGHAM",
"SHIFNAL",
"SHILDON",
"SHIPLEY",
"SHIPSTON-ON-STOUR",
"SHOREHAM-BY-SEA",
"SHREWSBURY",
"SIDCUP",
"SIDMOUTH",
"SITTINGBOURNE",
"SKEGNESS",
"SKELMERSDALE",
"SKIPTON",
"SLEAFORD",
"SLOUGH",
"SMETHWICK",
"SNODLAND",
"SOLIHULL",
"SOMERTON",
"SOUTH BRENT",
"SOUTH CROYDON",
"SOUTH MOLTON",
"SOUTH OCKENDON",
"SOUTH PETHERTON",
"SOUTH SHIELDS",
"SOUTHALL",
"SOUTHAM",
"SOUTHAMPTON",
"SOUTHEND-ON-SEA",
"SOUTHMINSTER",
"SOUTHPORT",
"SOUTHSEA",
"SOUTHWELL",
"SOUTHWOLD",
"SOWERBY BRIDGE",
"SPALDING",
"SPENNYMOOR",
"SPILSBY",
"ST AGNES",
"ST ALBANS",
"ST ASAPH",
"ST AUSTELL",
"ST BEES",
"ST COLUMB",
"ST HELENS",
"ST IVES",
"ST LEONARDS-ON-SEA",
"ST NEOTS",
"ST. AGNES",
"ST. ALBANS",
"ST. ASAPH",
"ST. AUSTELL",
"ST. BEES",
"ST. COLUMB",
"ST. HELENS",
"ST. IVES",
"ST. LEONARDS-ON-SEA",
"ST. NEOTS",
"STAFFORD",
"STAINES",
"STAINES-UPON-THAMES",
"STALYBRIDGE",
"STAMFORD",
"STANFORD-LE-HOPE",
"STANLEY",
"STANMORE",
"STANSTED",
"STEVENAGE",
"STEYNING",
"STOCKBRIDGE",
"STOCKPORT",
"STOCKSFIELD",
"STOCKTON-ON-TEES",
"STOKE-ON-TRENT",
"STOKE-SUB-HAMDON",
"STONE",
"STONEHOUSE",
"STOURBRIDGE",
"STOURPORT-ON-SEVERN",
"STOWMARKET",
"STRATFORD-UPON-AVON",
"STREET",
"STROUD",
"STUDLEY",
"STURMINSTER NEWTON",
"SUDBURY",
"SUNBURY-ON-THAMES",
"SUNDERLAND",
"SURBITON",
"SUTTON",
"SUTTON COLDFIELD",
"SUTTON-IN-ASHFIELD",
"SWADLINCOTE",
"SWAFFHAM",
"SWANAGE",
"SWANLEY",
"SWANSCOMBE",
"SWANSEA",
"SWINDON",
"TADCASTER",
"TADLEY",
"TADWORTH",
"TALSARNAU",
"TALYBONT",
"TAMWORTH",
"TARPORLEY",
"TAUNTON",
"TAVISTOCK",
"TEDDINGTON",
"TEIGNMOUTH",
"TELFORD",
"TEMPLECOMBE",
"TENBURY WELLS",
"TENBY",
"TENTERDEN",
"TETBURY",
"TEWKESBURY",
"THAME",
"THAMES DITTON",
"THATCHAM",
"THETFORD",
"THIRSK",
"THORNTON HEATH",
"THORNTON-CLEVELEYS",
"TIDWORTH",
"TILBURY",
"TINTAGEL",
"TIPTON",
"TIVERTON",
"TODMORDEN",
"TONBRIDGE",
"TONYPANDY",
"TORPOINT",
"TORQUAY",
"TORRINGTON",
"TOTLAND BAY",
"TOTNES",
"TOWCESTER",
"TREDEGAR",
"TREFRIW",
"TREGARON",
"TREHARRIS",
"TREORCHY",
"TRIMDON STATION",
"TRING",
"TROWBRIDGE",
"TRURO",
"TUNBRIDGE WELLS",
"TWICKENHAM",
"TY CROES",
"TYN-Y-GONGL",
"TYWYN",
"UCKFIELD",
"ULCEBY",
"ULVERSTON",
"UMBERLEIGH",
"UPMINSTER",
"USK",
"UTTOXETER",
"UXBRIDGE",
"VENTNOR",
"VERWOOD",
"VIRGINIA WATER",
"WADEBRIDGE",
"WADHURST",
"WAKEFIELD",
"WALLASEY",
"WALLINGFORD",
"WALLINGTON",
"WALLSEND",
"WALSALL",
"WALSINGHAM",
"WALTHAM ABBEY",
"WALTHAM CROSS",
"WALTON ON THE NAZE",
"WALTON-ON-THAMES",
"WANTAGE",
"WARE",
"WAREHAM",
"WARLINGHAM",
"WARMINSTER",
"WARRINGTON",
"WARWICK",
"WASHINGTON",
"WATCHET",
"WATERLOOVILLE",
"WATFORD",
"WATLINGTON",
"WEDMORE",
"WEDNESBURY",
"WELLING",
"WELLINGBOROUGH",
"WELLINGTON",
"WELLS",
"WELLS-NEXT-THE-SEA",
"WELSHPOOL",
"WELWYN",
"WELWYN GARDEN CITY",
"WEMBLEY",
"WEST BROMWICH",
"WEST BYFLEET",
"WEST DRAYTON",
"WEST MALLING",
"WEST MOLESEY",
"WEST WICKHAM",
"WESTBURY",
"WESTBURY-ON-SEVERN",
"WESTCLIFF-ON-SEA",
"WESTERHAM",
"WESTGATE-ON-SEA",
"WESTON-SUPER-MARE",
"WETHERBY",
"WEYBRIDGE",
"WEYMOUTH",
"WHITBY",
"WHITCHURCH",
"WHITEHAVEN",
"WHITLAND",
"WHITLEY BAY",
"WHITSTABLE",
"WHYTELEAFE",
"WICKFORD",
"WIDNES",
"WIGAN",
"WIGSTON",
"WIGTON",
"WILLENHALL",
"WILMSLOW",
"WIMBORNE",
"WINCANTON",
"WINCHELSEA",
"WINCHESTER",
"WINDERMERE",
"WINDLESHAM",
"WINDSOR",
"WINGATE",
"WINKLEIGH",
"WINSCOMBE",
"WINSFORD",
"WIRRAL",
"WISBECH",
"WITHAM",
"WITHERNSEA",
"WITNEY",
"WOKING",
"WOKINGHAM",
"WOLVERHAMPTON",
"WOODBRIDGE",
"WOODFORD GREEN",
"WOODHALL SPA",
"WOODSTOCK",
"WOOLACOMBE",
"WOOLER",
"WORCESTER",
"WORCESTER PARK",
"WORKINGTON",
"WORKSOP",
"WORTHING",
"WOTTON-UNDER-EDGE",
"WREXHAM",
"WYLAM",
"WYMONDHAM",
"Y FELINHELI",
"YARM",
"YARMOUTH",
"YATELEY",
"YELVERTON",
"YEOVIL",
"YORK",
"YSTRAD MEURIG"

        };
        private List<string> countyList = new List<string>
        {
            "HERTFORDSHIRE",
"CEREDIGION",
"RHONDDA CYNON TAFF",
"MID GLAMORGAN",
"POWYS",
"GWYNEDD",
"BLAENAU GWENT",
"MONMOUTHSHIRE",
"GWENT",
"NEWPORT",
"CONWY",
"DENBIGHSHIRE",
"CLWYD",
"CAERPHILLY",
"OXFORDSHIRE",
"LANCASHIRE",
"BLACKBURN WITH DARWEN",
"SURREY",
"WARWICKSHIRE",
"WORCESTERSHIRE",
"SUFFOLK",
"CHESHIRE",
"CHESHIRE EAST",
"HAMPSHIRE",
"LINCOLNSHIRE",
"DERBYSHIRE",
"NORTHUMBERLAND",
"ESSEX",
"CUMBRIA",
"GREATER MANCHESTER",
"WESTMORLAND AND FURNESS",
"BUCKINGHAMSHIRE",
"ISLE OF ANGLESEY",
"DYFED",
"CARMARTHENSHIRE",
"NEATH PORT TALBOT",
"SWANSEA",
"WILTSHIRE",
"BEDFORDSHIRE",
"CENTRAL BEDFORDSHIRE",
"WEST SUSSEX",
"WINDSOR AND MAIDENHEAD",
"BRACKNELL FOREST",
"WEST BERKSHIRE",
"STAFFORDSHIRE",
"LEICESTERSHIRE",
"LEICESTER",
"KENT",
"GREATER LONDON",
"TYNE AND WEAR",
"NORFOLK",
"AVON",
"SOMERSET",
"NORTH SOMERSET",
"DEVON",
"MILTON KEYNES",
"GLOUCESTERSHIRE",
"SOUTH GLOUCESTERSHIRE",
"FLINTSHIRE",
"CAMBRIDGESHIRE",
"NORTHAMPTONSHIRE",
"WEST NORTHAMPTONSHIRE",
"DURHAM",
"COUNTY DURHAM",
"NORTH YORKSHIRE",
"NORTH LINCOLNSHIRE",
"SOUTH YORKSHIRE",
"WEST YORKSHIRE",
"HUMBERSIDE",
"THE VALE OF GLAMORGAN",
"SOUTH GLAMORGAN",
"THURROCK",
"BATH AND NORTH EAST SOMERSET",
"EAST SUSSEX",
"DORSET",
"BEDFORD",
"ISLE OF WIGHT",
"EAST RIDING OF YORKSHIRE",
"SHROPSHIRE",
"STOCKTON-ON-TEES",
"HARTLEPOOL",
            "WEST MIDLANDS",
            "MERSEYSIDE",
            "DARLINGTON",
            "BLACKPOOL",
            "CORNWALL",
"PEMBROKESHIRE",
"BOURNEMOUTH",
"POOLE",
"BOURNEMOUTH",  
"CHRISTCHURCH AND POOLE",
"WOKINGHAM",
"BRIDGEND",
"CARDIFF",
"BRIGHTON AND HOVE",
"CITY OF BRISTOL",
"TORBAY",
"HEREFORDSHIRE",
"CUMBERLAND",
"YORK",
"MEDWAY",
"CHESHIRE WEST AND CHESTER",
"NORTH EAST LINCOLNSHIRE",
"NORTH NORTHAMPTONSHIRE",
"HEREFORD AND WORCESTER",
"TORFAEN",
"CITY OF DERBY",
"THAMESDOWN",
"SWINDON",
"NOTTINGHAMSHIRE",
"LUTON",
"SOUTHAMPTON",
"HALTON",
"REDCAR AND CLEVELAND",
"CLEVELAND",
"MIDDLESBROUGH",
"CITY OF KINGSTON UPON HULL",
"SOUTHEND-ON-SEA",
"BERKSHIRE",
"ISLES OF SCILLY",
"SLOUGH",
"STOKE-ON-TRENT",
"RUTLAND",
"WREXHAM",
"WARRINGTON",
"MERTHYR TYDFIL",
"WEST GLAMORGAN",
"READING",
"WREKIN",
"CITY OF NOTTINGHAM",
"CITY OF PETERBOROUGH",
"CITY OF PLYMOUTH",
"PORTSMOUTH"

        };
        private List<double> predictedPrices = new List<double>();


        public MainPage()
        {
            InitializeComponent();


            townCitySearchResults.ItemSelected += CityListView_ItemSelected;
            CountySearchResults.ItemSelected += CountyListView_ItemSelected;
        }






        private async void OnPredictClicked(object sender, EventArgs e)
        {
            var selectedType = PropertyTypePicker.SelectedItem?.ToString();
            var firstLetter = selectedType?.Substring(0, 1);

            try
            {
                // Construct the JSON data to send to the API
                string jsonData = "{" +
                    $"\"Year\": {YearEntry.Text}," +
                    $"\"Town/City\": \"{TownCityEntry.Text}\"," +
                    $"\"County\": \"{CountyEntry.Text}\"," +
                    $"\"Property_Type\": \"{firstLetter}\"," +
                    $"\"New_Build\": {NewBuildSwitch.IsToggled.ToString().ToLower()}," + // Convert bool to lowercase string
                    $"\"Current_Price\": {CurrentPriceEntry.Text}" +
                    "}";

                // Create HttpClient instance
                HttpClient client = new HttpClient();

                // Create StringContent with JSON data
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send POST request to the API
                HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to get the prediction
                    dynamic predictionData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                    // Get the predicted prices from the response
                    dynamic predictions = predictionData.predictions;
                    dynamic growthRates = predictionData.growth_rates;

                    // Clear the list before storing new predictions
                    predictedPrices.Clear();

                    // Store the predictions in the global variable
                    for (int i = 0; i < predictions.Count; i++)
                    {
                        double predictedPrice = Convert.ToDouble(predictions[i]);
                        predictedPrices.Add(predictedPrice);
                    }

                    // Create an array of ChartEntry to hold the chart data for Price
                    var priceEntries = new List<ChartEntry>();

                    // Create an array of ChartEntry to hold the chart data for Percentage Increase
                    var percentageEntries = new List<ChartEntry>();

                    // Add predicted prices and percentage increase as entries to the charts
                    int startingYear = int.Parse(YearEntry.Text);
                    double initialPrice = Convert.ToDouble(CurrentPriceEntry.Text);
                    for (int i = 0; i < predictedPrices.Count; i++)
                    {
                        double growthRate = (predictedPrices[i] - initialPrice) / initialPrice * 100;

                        priceEntries.Add(new ChartEntry((float)predictedPrices[i])
                        {
                            Label = (startingYear + i).ToString(),
                            ValueLabel = "£" + predictedPrices[i].ToString("#,##0.00"),
                            Color = SKColor.Parse("#457173") // You can customize the color
                        });

                        percentageEntries.Add(new ChartEntry((float)growthRate)
                        {
                            Label = (startingYear + i).ToString(),
                            ValueLabel = growthRate.ToString("F2") + "%",
                            Color = SKColor.Parse("#457173") // You can customize the color
                        });
                    }

                    // Create a bar chart with the price entries
                    var priceChart = new BarChart() { Entries = priceEntries, LabelOrientation = Orientation.Horizontal , ValueLabelOrientation = Orientation.Horizontal };

                    // Create a line chart with the percentage increase entries
                    var percentageChart = new LineChart() { Entries = percentageEntries, LabelOrientation = Orientation.Horizontal ,ValueLabelOrientation  = Orientation.Horizontal};

                    // Set the charts to the ChartViews
                    PriceChart.Chart = priceChart;
                    PercetangeChart.Chart = percentageChart;

                    // Display the predictions and growth rates
              
                    for (int i = 0; i < predictions.Count; i++)
                    {
                        double predictedPrice = Convert.ToDouble(predictions[i]);
                        double growthRate = Convert.ToDouble(growthRates[i]);

                        // Update the UI with the prediction and growth rate
                       
                        thirdFrame.IsVisible = true;    
                    }
                }
                else
                {
                    // Display error message if the response is not successful
                    
                }
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                
            }
        }



        private void OnTownCityTextChanged(object sender, TextChangedEventArgs e)
        {


            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                CityFrame.IsVisible = true;
            }
            else
            {
                CityFrame.IsVisible = false;
            }
            string searchText = e.NewTextValue.ToLower();
            List<string> searchResults = new List<string>();

            try
            {
                // Find matches in the town/city list
                foreach (var townCity in townCityList)
                {
                    if (townCity.ToLower().Contains(searchText))
                    {
                        searchResults.Add(townCity);
                    }
                }

                // Display the search results in the ListView
                townCitySearchResults.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                // Handle errors
           
            }
        }

        private  void OnCountyTextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                CountyFrame.IsVisible = true;
            }
            else
            {
                CountyFrame.IsVisible = false;
            }
            string searchText = e.NewTextValue.ToLower();
            List<string> searchResults = new List<string>();

            try
            {
                // Find matches in the town/city list
                foreach (var townCity in countyList)
                {
                    if (townCity.ToLower().Contains(searchText))
                    {
                        searchResults.Add(townCity);
                    }
                }

                // Display the search results in the ListView
                CountySearchResults.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                // Handle errors
               
            }
        }

        private void CityListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TownCityEntry.Text = e.SelectedItem.ToString();
                CityFrame.IsVisible = false;
            }
        }

        private void CountyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CountyEntry.Text = e.SelectedItem.ToString();
                CountyFrame.IsVisible = false;
            }
        }



        private void OnNextClicked(object sender, EventArgs e)
        {
            secondFrame.IsVisible = true;
            firstFrame.IsVisible = false;
            
        }


        private void OnBackClicked(object sender, EventArgs e)
        {
            secondFrame.IsVisible = false;
            firstFrame.IsVisible = true;

        }
        private void OnNewClicked(object sender, EventArgs e)
        {
            secondFrame.IsVisible = true;
            firstFrame.IsVisible = true;
            thirdFrame.IsVisible = false;

        }











    }

}

