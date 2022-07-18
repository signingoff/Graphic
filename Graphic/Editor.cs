using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEdit
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
            });
        }

        private void ellipseButton1_MouseHover(object sender, EventArgs e)
        {
           // ellipseButton1._hasMouseHover = !ellipseButton1._hasMouseHover;
           // ellipseButton1.Refresh();
        }

        private void ellipseButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dd");
        }
    }
}

public class FolderFileNode : TreeNode
{
    public readonly string _path;

    public readonly bool _isFile;

    public FolderFileNode(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
        Text = Path.GetFileName(path);
        _isFile = File.Exists(path);
        _path = path;
        SetIcon();
    }

    public void SetIcon()
    {
        // image[2] is Folder Open image
        ImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
        SelectedImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
    }

    private IEnumerable<string> _children;
    public void LoadNodes()
    {
        if (!_isFile && _children == null)
        {
            _children = Directory.EnumerateFileSystemEntries(_path);
            Nodes.AddRange(
                _children.Select(x =>
                    // co-variant
                    (TreeNode)new FolderFileNode(x))
                    .ToArray());
        }
    }
}
