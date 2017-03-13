using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.wpf.common.Model
{
    public class TreeViewItemModel : ViewModelBase, ITreeLocationModel
    {
        static readonly TreeViewItemModel DummyChild = new TreeViewItemModel();

        readonly ObservableCollection<TreeViewItemModel> _children;
        readonly TreeViewItemModel _parent;

        bool _isExpanded;
        bool _isSelected;


        protected TreeViewItemModel(TreeViewItemModel parent, bool lazyLoadChildren)
        {
            _parent = parent;

            _children = new ObservableCollection<TreeViewItemModel>();

            if (lazyLoadChildren)
                _children.Add(DummyChild);
        }

        private TreeViewItemModel()
        {
        }

        public ObservableCollection<TreeViewItemModel> Children
        {
            get { return _children; }
        }

        public bool HasDummyChild
        {
            get
            {
                return this.Children.Count == 1 && this.Children[0] == DummyChild;
            }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    RaisePropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;

                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.Children.Remove(DummyChild);
                    this.LoadChildrenAsync();
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        protected virtual void LoadChildrenAsync()
        { }

        public TreeViewItemModel Parent
        {
            get { return _parent; }
        }

        public virtual int GetLocationLevel
        {
            get { return 0; }
        }

        public virtual string GetName => throw new NotImplementedException();

        public virtual int GetID => throw new NotImplementedException();
    }
}
