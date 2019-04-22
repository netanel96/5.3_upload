using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_MVVM_EntityFramework.Commands;
using wpf_MVVM_EntityFramework.Model;

namespace wpf_MVVM_EntityFramework.ViewModel
{
    public class DropsMapVM
    {
        MainModel MainModel { set; get; }

        public ObservableCollection<MapPropsModel> MapProps { get; set; }

        public ShowDropsCommand ShowDropsCommand { get; set; }
        public DropsMapVM()
        {
            MainModel = new MainModel();

            this.ShowDropsCommand = new ShowDropsCommand(this);
            this.MapProps = new ObservableCollection<MapPropsModel>();
            this.MapProps.Add(new MapPropsModel() { Name = "usa ", Latitude = "38.8833N", Longitude = "77.0167W", Color = "Blue" });








            /////////////////////////////
            //////this is suppose to come from the user. in add report window.
            List<Report> reports = new List<Report>()
        {
                  new Report
                  {
                    Id = 10,
                    Report_Id=23,
                    Time = new DateTime(2000,10,10),
                    Name = "Moshe",
                    Report_Adress = "הזמיר 4 , יבנה , ישראל",
                    Boom_count = 0,
                    ImagePath = "imagePath",
                    lat = 31.874153,
                    log = 34.741990
                  },
                  new Report {
                Id = 11,
                Report_Id= 24,
                Time = new DateTime(2019,10,10),
                Name = "Netanel",
                Report_Adress = "הרצל 200 ,רחובות ,ישראל",
                Boom_count = 0,
                ImagePath = "imagePath",
                lat = 31.898865,
                log = 34.810445
               
                  }
        };
            //////

           // MainModel.BL.AddReport(reports[1]);

            List<Report> reportsFromDB = new List<Report>();
            //reportsFromDB.Add(MainModel.BL.GetReportById(23));
            //reportsFromDB.Add(MainModel.BL.GetReportById(24));
            //list of real reports in israel in yellow points
            List<Report> Report_List = new List<Report>()
            {
          new Report{lat=32.184448,log= 34.870766 },
          new Report{lat=31.705791,log= 35.200657},
          new Report{lat=31.801447,log= 34.643497},
          new Report{lat=32.699635,log= 35.303547},
          new Report{lat=32.017136,log= 34.745441},
          new Report{lat=32.109333,log= 34.855499},
          new Report{lat=32.794044,log= 34.989571},
          new Report{lat=32.919945,log= 35.290146},
          new Report{lat=32.166313,log= 34.843311},
          new Report{lat=31.894756,log= 34.809322},
          new Report{lat=31.771959,log= 35.217018}
        };
            for (int i = 0; i < Report_List.Count; i++)
            {
                MapProps.Add(new MapPropsModel() { Name = "USA ", Latitude = Report_List[i].lat.ToString(), Longitude = Report_List[i].log.ToString(), Color = "Yellow" });
            }
            //CalculateEstimateDrop in red points
            //num of clusters is 3
            List<Drop> EstimatedDrops=MainModel.BL.CalculateEstimateDrop(Report_List);

            ////////////////FORTESTING/////////////////
            MainModel.BL.AddDrop(EstimatedDrops[0]);
            MainModel.BL.GetDropById(EstimatedDrops[0].Drop_Id);
            Drop d1 = MainModel.BL.GetDropById(EstimatedDrops[0].Drop_Id);
            Drop d2 = EstimatedDrops[1];

            //Drop d1 = new Drop
            //{
            //    Id = i,
            //    Drop_Id = 207544131,
            //    Drop_Adress = "ישראל יבנה הזמיר 4",
            //    Drop_time = new DateTime(2010, 10, 10),

            //    Reports_list = r,
            //    Real_lat = 0,
            //    Real_log = 0,
            //    Estimeated_lat = resultedLatLog[i][0],
            //    Estimeated_log = resultedLatLog[i][1],
            //};     
            ////d1 lat:32.804541333333333  log:35.194421333333331
            ///d2 lat:31.738875 log 35.2088375
            ///distance: 118606.742 
            ///
            float distance =MainModel.BL.EvaluateDistance(d1,d2);
            //  int yy = 0;
            // MainModel.BL.RemoveDrop(EstimatedDrops[0].Drop_Id);
            ////////////////FORTESTING/////////////////

            for (int i = 0; i < EstimatedDrops.Count; i++)
            {
                MapProps.Add(new MapPropsModel() { Name = "USA ", Latitude = EstimatedDrops[i].Estimeated_lat.ToString(), Longitude = EstimatedDrops[i].Estimeated_log.ToString(), Color = "Red" });
            }
            //d for dubg i used:  Debug.WriteLine(MainModel.BL.GetReportById(24).Report_Adress);
            
            Debug.WriteLine("Hello");
        }
        public void ShowDropsOnMap()
        {
           Debug.WriteLine("Hello");
          
        }
    }
}

