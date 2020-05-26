using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EnglishPlans.Model;
using EnglishPlans.Service;
using GalaSoft.MvvmLight;

namespace EnglishPlans.ViewModel
{
    public class ReviewViewModel:ViewModelBase
    {

        #region Constructors

        public ReviewViewModel(IDataService dataService)
        {
            this._dataService = dataService;
        }

        #endregion Constructors

        #region  Fields

        private IDataService _dataService;

        private ListCollectionView _listCollectionView;

        #endregion Fields

        #region Properties

        #region Full Properties

        #endregion Full Properties

        #region MVVMProperties

        private ObservableCollection<EnglishWordModel> _englishWordModels;

        public ObservableCollection<EnglishWordModel> EnglishWords
        {
            get { return _englishWordModels; }
            set { Set("EnglishWords", ref _englishWordModels, value); }
        }

        #endregion MVVMProperties

        #region CommandPropertes 

        #endregion CommandPropertes 

        #endregion Properties

        #region Methods
        public void UpdateEnglishWords()
        {
            EnglishWords = new ObservableCollection<EnglishWordModel>(_dataService.GetReviewEnglishWords());

            _listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(EnglishWords);

            _listCollectionView.SortDescriptions.Add(new System.ComponentModel.SortDescription("CreateTime", System.ComponentModel.ListSortDirection.Descending));

            _listCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("CreateTime"));
        }

        #endregion Methods

        #region EventHandlers

        #region Windows
        #endregion Windows

        #endregion EventHandlers

    }
}
