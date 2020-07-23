using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class RadioGroup : UserControl
    {
        public RadioGroup()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Созданный компонент для группировки радиобаттонов
        /// </summary>
        [ProvideProperty("GroupName", typeof(RadioButton))]
        public partial class RadioGroup1 : Component, IExtenderProvider
        {
            private readonly Dictionary<RadioButton, string> _groups = new Dictionary<RadioButton, string>();

            public RadioGroup1()
            {

            }

            public RadioGroup1(IContainer container)
            {
                container.Add(this);
            }

            public string GetGroupName(RadioButton rdo) => _groups.TryGetValue(rdo, out var group) ? group : string.Empty;
            public void SetGroupName(RadioButton rdo, string group)
            {
                if (rdo == null)
                    return;

                if (group == null)
                    group = string.Empty;

                if (group == string.Empty)
                {
                    _groups.Remove(rdo);
                    rdo.Click -= OnRadioClicked;
                }
                else
                {
                    var currentChecked = GetChecked(group);

                    rdo.AutoCheck = false;
                    if (currentChecked != null)
                        rdo.Checked = false;
                    _groups[rdo] = group;
                    rdo.Click += OnRadioClicked;
                }
            }

            private void OnRadioClicked(object sender, EventArgs e)
            {
                var rdo = sender as RadioButton;
                if (rdo.Checked)
                    return;

                var currentChecked = GetChecked(GetGroupName(rdo));
                if (currentChecked != null)
                    currentChecked.Checked = false;

                rdo.Checked = true;
            }
            private RadioButton GetChecked(string groupName)
            {
                var radios = from pair in _groups
                             where pair.Value == groupName && pair.Key.Checked
                             select pair.Key;

                return radios.FirstOrDefault();
            }

            bool IExtenderProvider.CanExtend(object extendee) => extendee is RadioButton;
        }

        internal void SetGroupName(RadioButton radio, string v)
        {
            throw new NotImplementedException();
        }
    }
}
