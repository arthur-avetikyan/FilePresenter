using System;
using Microsoft.AspNetCore.Components;
using Presenter.DataProvider;
using Presenter.Models;

namespace Presenter.Pages
{
    public partial class Index
    {

        [Inject] private DataProviderFactory Factory { get; set; }

        private DirectoryModel _directory;

        protected override void OnInitialized()
        {
            _directory = Factory.GetXmlDataProvider().ProvideData();
            
        }
    }
}
