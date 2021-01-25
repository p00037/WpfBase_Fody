using Newtonsoft.Json;
using Reactive.Bindings;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfBase.Common;
using WpfBase.UseCase.Exceptions;

namespace WpfBase.Framework
{
    public abstract class MasterViewModelBase<TEntity> : ViewModelBase where TEntity : new()
    {
        public MasterViewModelBase()
        {
            BtnRegistrationCommand.Subscribe(_ => BtnRegistrationAction());
            BtnNewCommand.Subscribe(_ => BtnNewAction());
            BtnDeleteCommand.Subscribe(_ => BtnDeleteAction());
            BtnReturnCommand.Subscribe(x => BtnReturnAction(x));
            LoadedCommand.Subscribe(_ => LoadAction());
            BtnSearchCommand.Subscribe(_ => SearchAction());
            DataGridMouseDoubleClickComand.Subscribe(_ => DataGridMouseDoubleClickAction());
        }

        public TEntity EditData { get; set; } =new TEntity();

        public ObservableCollection<TEntity> SearchResultEntitys { get; set; } = new ObservableCollection<TEntity>();

        public string ErrorMessage { get; set; } = "";

        public int ErrorMessageBorderThickness { get; set; } = 0;

        public Brush ErrorMessageBackColor { get; set; } = new SolidColorBrush(Colors.Transparent);

        public bool IsPrimaryKeyEnabled { get; set; } = true;

        public bool IsBtnDeleteEnabled { get; set; } = true;

        public TEntity SelectedItem { get; set; } = new TEntity();

        public ReactiveCommand BtnSearchCommand { get; } = new ReactiveCommand();

        public ReactiveCommand DataGridMouseDoubleClickComand { get; } = new ReactiveCommand();

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnRegistrationCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnNewCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnDeleteCommand { get; } = new ReactiveCommand();

        public ReactiveCommand<object> BtnReturnCommand { get; } = new ReactiveCommand<object>();

        protected string JsonBeforeEditData { get; set; }

        protected ComEnum.EnmEditMode EditMode { get; set; } = ComEnum.EnmEditMode.Insert;

        public void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                var grd = (DataGrid)sender;
                grd.BeginEdit(e);
            }
        }

        public void LoadAction()
        {
            SetSearchResultEntitys();
            Load();
            ChangeEditModeToInsert();
        }

        public void SearchAction()
        {
            SetSearchResultEntitys();
        }

        public void DataGridMouseDoubleClickAction()
        {
            ChangeEditData();
        }

        public void BtnRegistrationAction()
        {
            try
            {
                ClearErrorMessage();
                Save();

                SetSearchResultEntitys();
                ChangeEditModeToInsert();
                MessageBox.Show(ComMessage.RESISTERED);
            }
            catch (SaveErrorMessageExcenption ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        public void BtnNewAction()
        {
            ChangeEditModeToInsert();
        }       

        public void BtnDeleteAction()
        {
            Delete();

            SetSearchResultEntitys();
            ChangeEditModeToInsert();
            MessageBox.Show(ComMessage.DELETED);
        }
        
        public void BtnReturnAction(object view)
        {
            ((Window)view).Close();
        }

        protected void ChangeEditModeToInsert()
        {
            ClearErrorMessage();
            IsPrimaryKeyEnabled = true;
            IsBtnDeleteEnabled = false;
            this.EditMode = ComEnum.EnmEditMode.Insert;
            SetEditDataWhenNew();
            SetBeforeEditData();
        }

        protected void ChangeEditModeToUpdate(TEntity selectEntity)
        {
            ClearErrorMessage();
            IsPrimaryKeyEnabled = false;
            IsBtnDeleteEnabled = true;
            this.EditMode = ComEnum.EnmEditMode.Update;
            SetEditDataWhenUpdate(selectEntity);
            SetBeforeEditData();
        }

        protected void SetErrorMessage(string errorMessage)
        {
            if (errorMessage == "")
            {
                ClearErrorMessage();
            }
            else
            {
                ErrorMessage = errorMessage;
                ErrorMessageBorderThickness = 1;
                ErrorMessageBackColor = new SolidColorBrush(Colors.White);
            }
        }

        protected void ClearErrorMessage()
        {
            ErrorMessage = "";
            ErrorMessageBorderThickness = 0;
            ErrorMessageBackColor = new SolidColorBrush(Colors.Transparent);
        }

        protected bool CheckChangeData()
        {
            if (this.JsonBeforeEditData == GetJsonEditData())
            {
                return false;
            }

            return true;
        }

        protected void SetBeforeEditData()
        {
            this.JsonBeforeEditData = GetJsonEditData();
        }

        protected abstract void Load();

        protected abstract void Save();

        protected abstract void Delete();

        protected abstract void SetEditDataWhenNew();

        protected abstract void SetEditDataWhenUpdate(TEntity selectEntity);

        protected abstract void SetSearchResultEntitys();

        protected virtual string GetJsonEditData()
        {
            return JsonConvert.SerializeObject(this.EditData);
        }

        private void ChangeEditData()
        {
            if (SelectedItem == null) return;

            if (ConfirmChangEditData() == false) return;

            ChangeEditModeToUpdate(SelectedItem);
        }

        private bool ConfirmChangEditData()
        {
            if (CheckChangeData() == false) return true;

            if (MessageBox.Show(ComMessage.CONFIM_CHANGE_DATA, "変更確認", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                return true;
            }

            return false;
        }
    }
}
