using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    ///数据模型基类，所有继承的ViewModel全部从此继承，封装了继承本操作
    /// </summary>
    public class TreeViewItemViewModel : INotifyPropertyChanged
    {
        #region Data

        static readonly TreeViewItemViewModel DummyChild = new TreeViewItemViewModel();

        readonly ObservableCollection<TreeViewItemViewModel> _children;
        readonly TreeViewItemViewModel _parent;

        bool _isExpanded;
     

        

        #endregion // Data

        #region Constructors

        protected TreeViewItemViewModel(TreeViewItemViewModel parent, bool lazyLoadChildren)
        {
            _parent = parent;

            _children = new ObservableCollection<TreeViewItemViewModel>();

            if (lazyLoadChildren)
                _children.Add(DummyChild);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private TreeViewItemViewModel()
        {
        }

        #endregion // Constructors

        #region Presentation Members

        #region Children

        /// <summary>
        /// 返回子对象
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get { return _children; }
        }

        #endregion/// 孩子对象

        #region HasLoadedChildren

        /// <summary>
        ///如果设备树上节点还没有被单击，那么使用假对象（预先加载的对象）
        /// </summary>
        public bool HasDummyChild
        {
            get { return this.Children.Count == 1 && this.Children[0] == DummyChild; }
        }

        #endregion //是否加载对象

        #region IsExpanded

        /// <summary>
        ///判断节点是否展开
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // 将父亲节点展开
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;

                //假如存在假节点，那么移除假节点，加载实际数据
                if (this.HasDummyChild)
                {
                    this.Children.Remove(DummyChild);
                    this.LoadChildren();
                }
            }
        }

        #endregion 



        #region LoadChildren

        /// <summary>
        /// 加载孩子对象，在继承的ViewModel中重载该函数，以定义不同的加载方式
        /// </summary>
        protected virtual void LoadChildren()
        {
        }

        /// <summary>
        /// 每个Item对象的图标
        /// </summary>
        public virtual BitmapImage ImageSource
        {
            get { return null; }
        }
        #endregion // 加载对象

        #region Parent

        /// <summary>
        /// 父亲节点数据
        /// </summary>
        public TreeViewItemViewModel Parent
        {
            get { return _parent; }
        }

        #endregion // 父亲节点数据

        #endregion // 消息通知

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // 属性更改后消息通知

        #region command
        
        #endregion
    }
}