﻿using DO;
using System.Collections.Generic;


namespace DS
{
    public static class DataSource

    {
        public static List<Station> listStations;//list of stations
        public static List<LineStation> listLineStation;//list of line stations
        public static List<Line> listLines;//list of lines
        public static List<User> listUser;//list of users
        public static List<LineTrip> listLineTrip;//list of line trip
        public static List<Trip> listTrip;//list of trips
        public static List<AdjacentStations> listAdjacentStations;//list of AdjacentStations
        static DataSource()
        {
            InitAllLists();//inialize all lists
        }


        static void InitAllLists()
        {
            #region Boot Lines
            listLines = new List<Line>
            {
                new Line
            {
                Id =1,
                Code =1,
                Area = Areas.JERUSALEM,
                FirstStation = 73,
                LastStation =83
            },
            new Line
            {
                Id =2,
                Code =2,
                Area = Areas.JERUSALEM,
                FirstStation = 84,
                LastStation =89
            },

            new Line
            {
                Id =3,
                Code =3,
                Area = Areas.JERUSALEM,
                FirstStation = 90,
                LastStation =95
            },
            new Line
            {
                 Id =4,
                Code =4,
                Area = Areas.JERUSALEM,
                FirstStation = 97,
                LastStation =112
            },
            new Line
            {
                 Id =5,
                Code =5,
                Area = Areas.JERUSALEM,
                FirstStation = 110,
                LastStation =115
            },
            new Line
            {
                 Id =6,
                Code =6,
                Area = Areas.JERUSALEM,
                FirstStation = 116,
                LastStation =1486
            },
            new Line
            {
                 Id =7,
                Code =7,
                Area = Areas.JERUSALEM,
                FirstStation =1487 ,
                LastStation =1492
            },
            new Line
            {
                 Id =8,
                Code =8,
                Area = Areas.JERUSALEM,
                FirstStation = 1493,
                LastStation =1512
            },
            new Line
            {
                Id =9,
                Code =9,
                Area = Areas.JERUSALEM,
                FirstStation = 1514,
                LastStation =1524
            },
             new Line
            { Id =10,
                Code =10,
                Area = Areas.JERUSALEM,
                FirstStation = 1523,
                LastStation =122
            }


            };
            #endregion
            #region Boot stations//איתחול תחנות
            listStations = new List<Station>

            {
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Lattitude = 31.825302,
                    Longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Lattitude = 31.738425,
                    Longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Lattitude = 31.738676,
                    Longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Lattitude = 31.789128,
                    Longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Lattitude = 31.766358,
                    Longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Lattitude = 31.790758,
                    Longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Lattitude = 31.768643,
                    Longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Lattitude = 31.769899,
                    Longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Lattitude = 31.767064,
                    Longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Lattitude = 31.765863,
                    Longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.799804,
                    Longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Lattitude = 31.765717,
                    Longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.767265,
                    Longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.767084,
                    Longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.768759,
                    Longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.77002,
                    Longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Lattitude = 31.8003,
                    Longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Lattitude = 31.8,
                    Longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Lattitude = 31.797708,
                    Longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Lattitude = 31.797535,
                    Longitude = 35.217057
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Lattitude = 31.797535,
                    Longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Lattitude = 31.796818,
                    Longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Lattitude = 31.796129,
                    Longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Lattitude = 31.794631,
                    Longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Lattitude = 31.79508,
                    Longitude = 35.211684
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Lattitude = 31.796255,
                    Longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Lattitude = 31.798423,
                    Longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Lattitude = 31.798689,
                    Longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Lattitude = 31.799165,
                    Longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Lattitude = 31.797829,
                    Longitude = 35.205601
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Lattitude = 31.840063,
                    Longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Lattitude = 31.838481,
                    Longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
                    Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Lattitude = 31.837748,
                    Longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Lattitude = 31.840279,
                    Longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Lattitude = 31.843598,
                    Longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Lattitude = 31.766256,
                    Longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Lattitude = 31.76736,
                    Longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Lattitude = 31.770543,
                    Longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Lattitude = 31.768465,
                    Longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Lattitude = 31.759534,
                    Longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Lattitude = 31.761447,
                    Longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Lattitude = 31.761447,
                    Longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Lattitude = 31.759186,
                    Longitude = 35.189336
                },


             new Station
             {
                 Code = 1518,
                 Name = "פרץ ברנשטיין/נזר דוד",
                 Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
                 Lattitude = 31.759121,
                 Longitude = 35.189178
             },
              new Station
              {
                  Code = 1522,
                  Name = "מוזיאון ישראל/רופין",
                  Address = "  רחוב:דרך רופין  עיר: ירושלים ",
                  Lattitude = 31.774484,
                  Longitude = 35.204882
              },

             new Station
             {
                 Code = 1523,
                 Name = "הרצוג/טשרניחובסקי",
                 Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
                 Lattitude = 31.769652,
                 Longitude = 35.208248
             },
              new Station
              {
                  Code = 1524,
                  Name = "רופין/שד' הזז",
                  Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
                  Lattitude = 31.769652,
                  Longitude = 35.208248,
              },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Lattitude = 31.796033,
                    Longitude = 35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Lattitude = 31.794958,
                    Longitude = 35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Lattitude = 31.79617,
                    Longitude = 35.206158
                }





            };
            #endregion
            #region Boot Station Lines
            listLineStation = new List<LineStation>
            {
                new LineStation
                {
                LineId = 1,

                Station =76,

                LineStationIndex =1

                },
                 new LineStation
                {
                LineId = 1,

                Station =77,

                LineStationIndex =2

                },
                  new LineStation
                {
                LineId = 1,

                Station =78,

                LineStationIndex =3

                },

                new LineStation
                {
                    LineId =2,

                    Station =85,

                    LineStationIndex = 1
                },
                  new LineStation
                {
                    LineId =2,

                    Station =86,

                    LineStationIndex = 2
                },
                    new LineStation
                {
                    LineId =2,

                    Station =88,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =3,

                    Station =91,

                    LineStationIndex = 1
                },
                 new LineStation
                {
                    LineId =3,

                    Station =93,

                    LineStationIndex = 2
                }, new LineStation
                {
                    LineId =3,

                    Station =94,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =4,

                    Station =102,

                    LineStationIndex = 1
                },
                new LineStation
                {
                    LineId =4,

                    Station =103,

                    LineStationIndex = 2
                },
                new LineStation
                {
                    LineId =4,

                    Station =105,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =4,

                    Station =106,

                    LineStationIndex = 4
                },
                new LineStation
                {
                    LineId =4,

                    Station =108,

                    LineStationIndex = 5
                },
                new LineStation
                {
                    LineId =4,

                    Station =109,

                    LineStationIndex = 6
                },
                new LineStation
                {
                    LineId =4,

                    Station =110,

                    LineStationIndex = 7
                },
                new LineStation
                {
                    LineId =4,

                    Station =111,

                    LineStationIndex = 8
                },
                new LineStation
                {
                    LineId =5,

                    Station =111,

                    LineStationIndex = 1
                },
                 new LineStation
                {
                    LineId =5,

                    Station =112,

                    LineStationIndex = 2
                },
                  new LineStation
                {
                    LineId =5,

                    Station =113,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =6,

                    Station =117,

                    LineStationIndex = 1
                },
                 new LineStation
                {
                    LineId =6,

                    Station =119,

                    LineStationIndex = 2
                },
                 new LineStation
                {
                    LineId =6,

                    Station =1485,

                    LineStationIndex = 3
                },

                new LineStation
                {
                    LineId =7,

                    Station =1488,

                    LineStationIndex = 1
                },
                  new LineStation
                {
                    LineId =7,

                    Station =1490,

                    LineStationIndex = 2
                },  new LineStation
                {
                    LineId =7,

                    Station =1491,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =8,

                    Station =1494,

                    LineStationIndex = 1
                },
                new LineStation
                {
                    LineId =8,

                    Station =1510,

                    LineStationIndex = 2
                },
                new LineStation
                {
                    LineId =8,

                    Station =1511,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =9,

                    Station =1518,

                    LineStationIndex = 1
                },
                new LineStation
                {
                    LineId =9,

                    Station =1522,

                    LineStationIndex = 2
                },new LineStation
                {
                    LineId =9,

                    Station =1523,

                    LineStationIndex = 3
                },
                new LineStation
                {
                    LineId =10,

                    Station =1524,

                    LineStationIndex = 1
                },
                new LineStation
                {
                    LineId =10,

                    Station =121,

                    LineStationIndex = 2
                },new LineStation
                {
                    LineId =10,

                    Station =123,

                    LineStationIndex = 3
                },
            };
            #endregion
            #region AdjacentStations

            #endregion
        }
    }
}
