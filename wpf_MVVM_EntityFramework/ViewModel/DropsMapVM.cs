﻿using BE;
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

            MainModel.BL.AddReport(reports[0]);
            MainModel.BL.AddReport(reports[1]);

            List<Report> reportsFromDB = new List<Report>();
            reportsFromDB.Add(MainModel.BL.GetReportById(23));
            reportsFromDB.Add(MainModel.BL.GetReportById(24));
            for (int i = 0; i < reportsFromDB.Count; i++)
            {
                MapProps.Add(new MapPropsModel() { Name = "USA ", Latitude = reportsFromDB[i].lat.ToString(), Longitude = reportsFromDB[i].log.ToString(), Color = "Gray" });
            }
            //d
            Debug.WriteLine(MainModel.BL.GetReportById(24).Report_Adress);
        }
        public void ShowDropsOnMap()
        {
           Debug.WriteLine("Hello");
          
        }
    }
}

