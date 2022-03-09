using System.IO;
using System.Xml;
using Presenter.Models;

namespace Presenter.DataProvider
{
    internal class XMLDataProvider : IDataProvider
    {
        private const string FILENAME = "FileSystem.xml";
        private const string NAME_ATTRIBUTE = "Name";
        private const string PATH_ATTRIBUTE = "Path";

        private DirectoryModel _fileSystem;

        public DirectoryModel ProvideData()
        {
            XmlDocument doc = GetFile();
            _fileSystem = GetStructure(doc);
            return _fileSystem;
        }

        private XmlDocument GetFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);
            var doc = new XmlDocument();
            doc.Load(filePath);
            return doc;
        }

        private DirectoryModel GetStructure(XmlDocument doc)
        {
            XmlNode rootNode = doc.SelectSingleNode("Root");

            var rootComposite = new CompositeDirectoryModel(rootNode.Attributes[NAME_ATTRIBUTE]?.Value,
                                                            rootNode.Attributes[PATH_ATTRIBUTE]?.Value);
            GetChildNodes(rootNode, rootComposite);
            return rootComposite;
        }

        private void GetChildNodes(XmlNode rootNode, CompositeDirectoryModel rootComposite)
        {
            if (rootNode.HasChildNodes)
            {
                for (int i = 0; i < rootNode.ChildNodes.Count; i++)
                {
                    XmlNode node = rootNode.ChildNodes[i];
                    DecideIfComposite(rootComposite, node);
                }
            }
        }

        private void DecideIfComposite(CompositeDirectoryModel rootComposite, XmlNode node)
        {
            if (node.HasChildNodes)
            {
                ReadCompositeNodes(rootComposite, node);
            }
            else
            {
                ReadLeafNodes(rootComposite, node);
            }
        }

        private void ReadCompositeNodes(CompositeDirectoryModel rootComposite, XmlNode node)
        {
            CompositeDirectoryModel composite = new CompositeDirectoryModel(node.Attributes[NAME_ATTRIBUTE]?.Value,
                                                                            node.Attributes[PATH_ATTRIBUTE]?.Value);
            rootComposite.Add(composite);
            GetChildNodes(node, composite);
        }

        private static void ReadLeafNodes(CompositeDirectoryModel rootComposite, XmlNode node)
        {
            rootComposite.Add(new LeafDirectoryModel(node.Attributes[NAME_ATTRIBUTE]?.Value,
                                                     node.Attributes[PATH_ATTRIBUTE]?.Value));
        }
    }
}
