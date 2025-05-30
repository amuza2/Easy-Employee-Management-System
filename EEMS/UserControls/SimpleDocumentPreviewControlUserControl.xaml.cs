﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EEMS.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SimpleDocumentPreviewControlUserControl.xaml
    /// </summary>
    public partial class SimpleDocumentPreviewControlUserControl : UserControl
    {
        public SimpleDocumentPreviewControlUserControl()
        {
            InitializeComponent();
        }

        public FlowDocument Document
        {
            get { return documentViewer.Document; }
            set { documentViewer.Document = value; }
        }
    }
}
