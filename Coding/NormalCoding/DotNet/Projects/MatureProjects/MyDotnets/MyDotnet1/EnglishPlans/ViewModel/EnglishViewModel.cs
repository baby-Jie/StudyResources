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
using GalaSoft.MvvmLight.Command;

namespace EnglishPlans.ViewModel
{
    public class EnglishViewModel: ViewModelBase
    {

		#region Constructors

        public EnglishViewModel(IDataService dataService)
        {
            this._dataService = dataService;
        }

		#endregion Constructors

		#region  Fields

        private IDataService _dataService;

        private ListCollectionView _listCollectionView;

        #endregion Fields

        #region Properties

        private ObservableCollection<EnglishWordModel> _englishWordModels;

        public ObservableCollection<EnglishWordModel> EnglishWords
        {
            get { return _englishWordModels; }
            set { Set("EnglishWords", ref _englishWordModels, value); }
        }

        #region CommandProperty FoldCmd

        private RelayCommand _foldCmd;

        public RelayCommand FoldCmd
        {
            get
            {
                return _foldCmd ?? (_foldCmd = new RelayCommand(() =>
                {
                    var ret = from englishWord in EnglishWords where englishWord.IsExpanded select englishWord;
                    foreach (var englishWordModel in ret)
                    {
                        englishWordModel.IsExpanded = false;
                    }
                }));
            }
        }

        #endregion


        #endregion Properties

        #region Events

        #endregion Events

        #region Methods

        public void UpdateEnglishWords()
        {
            EnglishWords = new ObservableCollection<EnglishWordModel>(_dataService.GetEnglishWordModels());
            _listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(EnglishWords);

            _listCollectionView.SortDescriptions.Add(new System.ComponentModel.SortDescription("CreateTime", System.ComponentModel.ListSortDirection.Descending));

            _listCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("CreateTime"));
        }

        #endregion Methods

        #region EventHandlers


        #endregion EventHandlers

    }
}
