﻿using System.Windows.Controls;
using DevExpress.Xpf.Scheduling;

namespace DXSample.Views {
    public partial class SchedulingView : UserControl {
        public SchedulerControl Scheduler { get { return this.scheduler; } }
        public SchedulingView() {
            InitializeComponent();
        }
    }
}
