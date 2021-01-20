using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DS
{
    public static class DataSource

    {
       // static XElement linesRootElem;


       //static string lineTripsPath = @"LineTripsXml.xml"; //XElement
        public static List<Station> listStations;//list of stations
        public static List<LineStation> listLineStation;//list of line stations
        public static List<Line> listLines;//list of lines
        public static List<User> listUser;//list of users
        public static List<LineTrip> listLineTrip;//list of line trip
        public static List<Trip> listTrip;//list of trips
        public static List<AdjacentStations> listAdjacentStations;//list of AdjacentStations
        public static List<int> RunningNumber= new List<int>{11};//lis with running number
        static DataSource()
        {
            InitAllLists();//inialize all lists
            SaveListToXML(listStations, "..\\xml\\StationsXml.xml");
            SaveListToXML(listLineStation, "..\\xml\\LineStationsXml.xml");
            SaveListToXML(listLines, "..\\xml\\LinesXml.xml");
            SaveListToXML(listLineTrip, "..\\xml\\LineTripsXml.xml");
            SaveListToXML(RunningNumber, "..\\xml\\RunningNumberXml.xml");
            SaveListToXML(listAdjacentStations, "..\\xml\\AdjacentStationsXml.xml");



        }
        public static void SaveListToXML(List <int> num, string path)
        {
            XmlSerializer x = new XmlSerializer(num.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, num);
            fs.Close();
        }
        public static void SaveListToXML(List<AdjacentStations> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }



        public static void SaveListToXML(List<Station> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }
        public static void SaveListToXML(List<LineTrip> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }
        public static void SaveListToXML(List<LineStation> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }
        public static void SaveListToXML(List<Line> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
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
               #region line1
            new LineStation
                {
                LineId = 1,

                Station =73,

                LineStationIndex =0

                },
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
                LineId = 1,

                Station =83,

                LineStationIndex =4

                },
            #endregion 
               #region line2
                     new LineStation
                {
                    LineId =2,

                    Station =84,

                    LineStationIndex = 0
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
                    LineId =2,

                    Station =89,

                    LineStationIndex = 4
                },
                     #endregion 
               #region line3

                      new LineStation
                {
                    LineId =3,

                    Station =90,

                    LineStationIndex = 0
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
                },
                new LineStation
                {
                    LineId =3,

                    Station =94,

                    LineStationIndex = 3
                },
                 new LineStation
                {
                    LineId =3,

                    Station =95,

                    LineStationIndex = 4
                },
                 #endregion 
               #region line4
                  new LineStation
                {
                    LineId =4,

                    Station =97,

                    LineStationIndex = 0
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
                    LineId =4,

                    Station =112,

                    LineStationIndex = 9
                },
                 #endregion 
               #region line5
                new LineStation
                {
                    LineId =5,

                    Station =110,

                    LineStationIndex = 0
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
                    LineId =5,

                    Station =115,

                    LineStationIndex = 4
                },
                    #endregion 
               #region line6
                     new LineStation
                {
                    LineId =6,

                    Station =116,

                    LineStationIndex = 0
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
                    LineId =6,

                    Station =1486,

                    LineStationIndex = 4
                },
                  #endregion 
               #region line7
                   new LineStation
                {
                    LineId =7,

                    Station =1487,

                    LineStationIndex = 0
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
                    LineId =7,

                    Station =1492,

                    LineStationIndex = 4
                },
                  #endregion 
               #region line8
                   new LineStation
                {
                    LineId =8,

                    Station =1493,

                    LineStationIndex = 0
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
                    LineId =8,

                    Station =1512,

                    LineStationIndex = 4
                },
                #endregion 
               #region line9
                new LineStation
                {
                    LineId =9,

                    Station =1514,

                    LineStationIndex = 0
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
                    LineId =9,

                    Station =1524,

                    LineStationIndex = 4
                },
                #endregion 
               #region line 10
                 new LineStation
                {
                    LineId =10,

                    Station =1523,

                    LineStationIndex = 0
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
                 new LineStation
                {
                    LineId =10,

                    Station =122,

                    LineStationIndex = 4
                },
                 #endregion 
                    
            };
            #endregion
            #region AdjacentStations
            listAdjacentStations = new List<AdjacentStations>
            {

            new AdjacentStations
            {
                Station1 = 73,
                Station2 = 76,
                Distance = 5.0,
                Time = 10.0
            },
            new AdjacentStations
            {
                Station1 = 76,
                Station2 = 77,
                Distance = 3.0,
                Time = 6.0

            },
            new AdjacentStations
            {
                Station1 = 77,
                Station2 = 78,
                Distance = 2.0,
                Time = 4.0

            },

            new AdjacentStations
            {
                Station1 = 78,
                Station2 = 83,
                Distance = 5.0,
                Time = 10.0

            },


            new AdjacentStations
            {
                Station1 = 84,
                Station2 = 85,
                Distance = 1.0,
                Time = 2.0

            },
            new AdjacentStations
            {
                Station1 = 85,
                Station2 = 86,
                Distance = 2.0,
                Time = 4.0

            },
            new AdjacentStations
            {
                Station1 = 86,
                Station2 = 88,
                Distance = 4.0,
                Time = 8.0

            },
            new AdjacentStations
            {
                Station1 = 88,
                Station2 = 89,
                Distance = 2.0,
                Time = 4.0

            },
            new AdjacentStations
            {
                Station1 = 90,
                Station2 = 91,
                Distance = 3.0,
                Time = 6.0

            },
            new AdjacentStations
            {
                Station1 = 91,
                Station2 = 93,
                Distance = 3.5,
                Time = 7.0

            },
            new AdjacentStations
            {
                Station1 = 93,
                Station2 = 94,
                Distance = 2.2,
                Time = 4.4

            },
            new AdjacentStations
            {
                Station1 = 94,
                Station2 = 95,
                Distance = 0.8,
                Time = 1.6

            },
            new AdjacentStations
            {
                Station1 = 97,
                Station2 = 102,
                Distance = 6.0,
                Time = 12.0

            },
            new AdjacentStations
            {
                Station1 = 102,
                Station2 = 103,
                Distance = 0.5,
                Time = 1.0

            },
            new AdjacentStations
            {
                Station1 = 103,
                Station2 = 105,
                Distance = 2.6,
                Time = 5.2

            },
            new AdjacentStations
            {
                Station1 = 105,
                Station2 = 106,
                Distance = 1.0,
                Time = 2.0

            },
            new AdjacentStations
            {
                Station1 = 106,
                Station2 = 108,
                Distance = 3.7,
                Time = 7.4

            },
            new AdjacentStations
            {
                Station1 = 109,
                Station2 = 110,
                Distance = 1.2,
                Time = 2.4

            },
            new AdjacentStations
            {
                Station1 = 110,
                Station2 = 111,
                Distance = 0.4,
                Time = 0.8

            },
            new AdjacentStations
            {
                Station1 = 111,
                Station2 = 112,
                Distance = 0.9,
                Time = 1.8

            },
            new AdjacentStations
            {
                Station1 = 112,
                Station2 = 113,
                Distance = 1.2,
                Time = 2.4

            },
            new AdjacentStations
            {
                Station1 = 113,
                Station2 = 115,
                Distance = 1.9,
                Time = 3.8

            },
            new AdjacentStations
            {
                Station1 = 116,
                Station2 = 117,
                Distance = 0.3,
                Time = 0.6

            },
            new AdjacentStations
            {
                Station1 = 117,
                Station2 = 119,
                Distance = 1.5,
                Time = 3.0

            },
            new AdjacentStations
            {
                Station1 = 119,
                Station2 = 1485,
                Distance = 5.2,
                Time = 10.4

            },
            new AdjacentStations
            {
                Station1 = 1485,
                Station2 = 1486,
                Distance = 1.1,
                Time = 2.2

            },
            new AdjacentStations
            {
                Station1 = 1487,
                Station2 = 1488,
                Distance = 0.7,
                Time = 1.4

            },
            new AdjacentStations
            {
                Station1 = 1488,
                Station2 = 1490,
                Distance = 1.5,
                Time = 3.0

            },
            new AdjacentStations
            {
                Station1 = 1490,
                Station2 = 1491,
                Distance = 1.0,
                Time = 2.0

            },
            new AdjacentStations
            {
                Station1 = 1491,
                Station2 = 1492,
                Distance = 1.2,
                Time = 2.4

            },
            new AdjacentStations
            {
                Station1 = 1493,
                Station2 = 1494,
                Distance = 1.5,
                Time = 3.0

            },
            new AdjacentStations
            {
                Station1 = 1494,
                Station2 = 1510,
                Distance = 4.8,
                Time = 9.6

            },
            new AdjacentStations
            {
                Station1 = 1510,
                Station2 = 1511,
                Distance = 1.0,
                Time = 2.0

            },
            new AdjacentStations
            {
                Station1 = 1511,
                Station2 = 1512,
                Distance = 0.2,
                Time = 0.4

            },
            new AdjacentStations
            {
                Station1 = 1514,
                Station2 = 1518,
                Distance = 1.7,
                Time = 3.4
            },
            new AdjacentStations
            {
                Station1 = 1518,
                Station2 = 1522,
                Distance = 3.2,
                Time = 6.4
            },
            new AdjacentStations
            {
                Station1 = 1522,
                Station2 = 1523,
                Distance = 0.6,
                Time = 1.2
            },
            new AdjacentStations
            {
                Station1 = 1523,
                Station2 = 1524,
                Distance = 1.4,
                Time = 2.8
            },
            new AdjacentStations
            {
                Station1 = 1524,
                Station2 = 121,
                Distance = 5.5,
                Time = 11.0
            },
             new AdjacentStations
            {
                Station1 = 121,
                Station2 = 123,
                Distance = 1.25,
                Time = 2.5
            },
              new AdjacentStations
            {
                Station1 = 123,
                Station2 = 122,
                Distance = 0.5,
                Time = 1.0
            },


            };
            #endregion
            #region TripLine
            listLineTrip = new List<LineTrip>
            {
            #region Line 1
            new LineTrip
            {
                LineId=1,
               StartAt= new TimeSpan(7,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(8,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(9,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(10,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(11,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(12,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(13,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(14,0,0)
            },
              new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(15,0,0)
            },
                new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(16,0,0)
            },
                  new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(17,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(18,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(19,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(20,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(21,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(22,0,0)
            },
            new LineTrip
            {
                LineId=1,
                StartAt= new TimeSpan(23,0,0)
            },
            #endregion
            #region Line 2
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(7,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(7,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(8,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(8,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(9,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(9,45,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(10,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(10,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(11,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(11,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(12,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(12,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(13,15,0)
            },
            new LineTrip
            {
                LineId=2,
               StartAt= new TimeSpan(13,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(14,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(14,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(15,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(15,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(16,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(16,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(17,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(17,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(18,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(18,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(19,15,0)
            },  
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(19,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(20,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(20,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(21,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(21,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(22,15,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(22,45,0)
            },
            new LineTrip
            {
                LineId=2,
                StartAt= new TimeSpan(23,15,0)
            },
            #endregion
            #region Line 3
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(7,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(9,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(11,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(13,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(15,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(17,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(19,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(21,10,0)
            },
            new LineTrip
            {
               LineId=3,
               StartAt= new TimeSpan(23,10,0)
            },
            #endregion
            #region Line 4
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(7,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(8,0,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(8,40,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(9,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(10,0,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(10,40,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(11,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(12,0,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(12,40,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(13,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(14,0,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(14,40,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(15,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(16,0,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(16,40,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(17,20,0)
            },
            new LineTrip
            {
               LineId=4,
               StartAt= new TimeSpan(18,0,0)
            },

            #endregion
            #region Line 5
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(5,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(8,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(11,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(14,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(17,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(20,20,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(23,0,0)
            },
            new LineTrip
            {
               LineId=5,
               StartAt= new TimeSpan(23,20,0)
            },
            #endregion
            #region Line 6
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(5,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(6,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(7,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(8,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(9,0,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(9,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(10,0,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(10,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(11,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(12,0,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(13,0,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(13,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(14,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(15,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(16,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(17,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(18,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(19,30,0)
            },
            new LineTrip
            {
               LineId=6,
               StartAt= new TimeSpan(20,0,0)
            },
            
            #endregion
            #region Line 7
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(10,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(11,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(12,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(13,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(14,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(15,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(16,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(17,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(18,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(19,45,0)
            },
            new LineTrip
            {
               LineId=7,
               StartAt= new TimeSpan(20,45,0)
            },
            #endregion
            #region Line 8
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(8,5,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(8,55,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(9,45,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(10,35,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(11,25,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(12,15,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(13,5,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(13,55,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(14,45,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(15,35,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(16,25,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(17,15,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(18,05,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(18,55,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(19,45,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(20,35,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(21,25,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(22,15,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(23,5,0)
            },
            new LineTrip
            {
               LineId=8,
               StartAt= new TimeSpan(23,55,0)
            },

            #endregion
            #region Line 9
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(6,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(7,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(8,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(9,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(10,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(12,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(13,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(14,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(15,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(16,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(17,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(18,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(19,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(20,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(21,12,0)
            },
            new LineTrip
            {
               LineId=9,
               StartAt= new TimeSpan(22,12,0)
            },
            #endregion
            #region Line 10
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(6,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(6,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(6,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(6,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(7,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(7,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(7,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(7,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(8,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(8,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(8,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(8,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(9,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(9,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(9,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(9,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(10,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(10,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(10,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(10,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(11,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(11,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(11,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(11,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(12,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(12,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(12,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(12,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(13,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(13,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(13,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(13,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(14,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(14,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(14,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(14,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(15,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(15,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(15,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(15,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(16,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(16,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(16,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(16,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(17,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(17,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(17,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(17,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(18,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(18,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(18,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(18,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(19,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(19,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(19,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(19,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(20,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(20,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(20,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(20,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(21,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(21,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(21,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(21,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(22,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(22,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(22,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(22,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(23,0,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(23,15,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(23,30,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(23,45,0)
            },
            new LineTrip
            {
               LineId=10,
               StartAt= new TimeSpan(0,0,0)
            },
           
            #endregion
            };
            #endregion
            
        }


    }
}
