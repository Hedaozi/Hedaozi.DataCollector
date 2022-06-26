using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hedaozi.DataCollector.DataModels;

namespace Hedaozi.DataCollector.WPF.ViewModels
{
    internal class BaiduIndexVM: INotifyPropertyChanged
    {
        public readonly static Array AreaTypesEnum = Enum.GetValues(typeof(BaiduIndex.AreaType));
        public readonly static List<string> BelongsEnum = new List<string>(
            from node in BaiduIndex.Areas.FindAreas(BaiduIndex.AreaType.Province, null)
            select node.Belong
        );

        private BaiduIndex.AreaType areaType = BaiduIndex.AreaType.All;
        private List<string> belongs = new List<string>(
            from node in BaiduIndex.Areas.FindAreas(BaiduIndex.AreaType.Province, null)
            select node.Belong
        );

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BaiduIndex.AreaType AreaType
        {
            get { return areaType; }
            set
            {
                areaType = value;
                OnPropertyChanged("AreaType");
                OnPropertyChanged("SelectedAreas");
            }
        }

        public List<string> Belongs
        {
            get { return belongs; }
            set
            {
                belongs = value;
                OnPropertyChanged("Belongs");
                OnPropertyChanged("SelectedAreas");
            }
        }

        public List<BaiduIndex.Area> SelectedAreas
        {
            get { return BaiduIndex.Areas.FindAreas(AreaType, Belongs); }
        }
    }
}
