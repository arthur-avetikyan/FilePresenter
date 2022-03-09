namespace Presenter.Models
{
    class LeafDirectoryModel : DirectoryModel
    {
        public LeafDirectoryModel(string name, string path) : base(name, path)
        {

        }

        public override bool IsComposite => false;
    }
}
