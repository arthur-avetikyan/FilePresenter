using System;
using System.IO;
using System.Collections.Generic;

namespace Presenter.Models
{
    public abstract class DirectoryModel
    {
        protected string _name;
        protected string _path;

        protected DirectoryModel(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public virtual void Add(DirectoryModel leaf) => throw new NotImplementedException();

        public virtual void Remove(DirectoryModel leaf) => throw new NotImplementedException();

        public virtual IEnumerable<DirectoryModel> GetChildren() => throw new NotImplementedException();

        public abstract bool IsComposite { get; }

        public bool IsFile { get => !string.IsNullOrWhiteSpace(Path.GetExtension(_path)); }

        public string Display { get => _name; }

        public string Preview { get => _path; }
    }
}