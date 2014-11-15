﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetOffice.DeveloperToolbox.ToolboxControls.About
{
    public partial class AboutControl : UserControl, IToolboxControl
    {
        #region Ctor

        public AboutControl()
        {
            InitializeComponent();
            labelVersionText.Text = String.Format("Version {0}", AssemblyInfo.AssemblyVersion);
            labelCopyrightText.Text = AssemblyInfo.AssemblyCopyright;
        }

        #endregion

        #region IToolboxControl

        public IToolboxHost Host { get; private set; }

        public string ControlName
        {
            get { return "About.AboutControl"; }
        }

        public string ControlCaption
        {
            get { return "About"; }
        }

        public Image Icon
        {
            get { return Ressources.RessourceUtils.ReadImageFromRessource("ToolboxControls.About.info_rhombus.png"); }
        }

        public bool SupportsHelpContent
        {
            get
            {
                return false;
            }
        }

        public bool SupportsInfoMessage
        {
            get
            {
                return false;
            }
        }

        public ToolboxControlMessageKind InfoMessageKind
        {
            get
            {
                return ToolboxControlMessageKind.Uncategorized;
            }
        }

        public string InfoMessage
        {
            get
            {
                return String.Empty;
            }
        }

        public void InitializeControl(IToolboxHost host)
        {
            Host = host;
        }

        public void Activate(bool firstTime)
        {
            controlForeColorAnimator1.Start(false);
        }

        public void Deactivated()
        {
            controlForeColorAnimator1.Stop();
        }

        public void LoadComplete()
        {

        }

        public void LoadConfiguration(System.Xml.XmlNode configNode)
        {

        }

        public void SaveConfiguration(System.Xml.XmlNode configNode)
        {

        }

        public void SetLanguage(int id)
        {

        }

        public Stream GetHelpText(int lcid)
        {
            throw new NotImplementedException();
        }

        public new void KeyDown(KeyEventArgs e)
        {

        }

        public void Release()
        {

        }

        public IContainer Components
        {
            get { return components; }
        }

        #endregion

        #region Trigger

        private void AboutControl_Resize(object sender, EventArgs e)
        {
            try
            {
                panelMain.Location = new Point((this.Width / 2) - (panelMain.Width / 2), (this.Height / 2) - (panelMain.Height / 2));
            }
            catch (Exception exception)
            {
                Forms.ErrorForm.ShowError(this, exception, Forms.ErrorCategory.NonCritical, Host.CurrentLanguageID);
            }
        }

        private void linkLabelCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel label = sender as LinkLabel;
                System.Diagnostics.Process.Start(label.Text);
            }
            catch (Exception exception)
            {
                Forms.ErrorForm.ShowError(this, exception, Forms.ErrorCategory.NonCritical, Host.CurrentLanguageID);
            }
        }

        private void labelNetOfficeIsFree_Click(object sender, EventArgs e)
        {
            try
            {
                EasterEggControl ctrl = new EasterEggControl(Host.CurrentLanguageID);
                ctrl.Dock = DockStyle.Fill;
                Controls.Add(ctrl);
                ctrl.BringToFront();
                ctrl.Done += new EventHandler(EasterEgg_Done);
                ctrl.Visible = true;
                ctrl.ShowwGernot();
            }
            catch (Exception exception)
            {
                Forms.ErrorForm.ShowError(this, exception, Forms.ErrorCategory.NonCritical, Host.CurrentLanguageID);
            }
        }

        private void EasterEgg_Done(object sender, EventArgs e)
        {
            try
            {
                EasterEggControl ctrl = sender as EasterEggControl;
                if (null != ctrl && Controls.Contains(ctrl))
                {
                    Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
            catch (Exception exception)
            {
                Forms.ErrorForm.ShowError(this, exception, Forms.ErrorCategory.NonCritical, Host.CurrentLanguageID);
            }
        }

        #endregion
    }
}
