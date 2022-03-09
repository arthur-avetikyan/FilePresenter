namespace Presenter.DataProvider
{
    public class DataProviderFactory
    {
        public IDataProvider GetXmlDataProvider()
        {
            return new XMLDataProvider();
        }
    }
}
