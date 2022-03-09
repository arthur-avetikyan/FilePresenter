using System.Collections.Generic;

namespace Presenter.Models
{
    class CompositeDirectoryModel : DirectoryModel
    {
        protected List<DirectoryModel> _children;

        public CompositeDirectoryModel(string name, string path) : base(name, path)
        {
            _children = new List<DirectoryModel>();
        }

        public override bool IsComposite => true;

        public override void Add(DirectoryModel leaf) => _children.Add(leaf);

        public override void Remove(DirectoryModel leaf) => _children.Remove(leaf);

        public override IEnumerable<DirectoryModel> GetChildren() => _children;
    }
}
