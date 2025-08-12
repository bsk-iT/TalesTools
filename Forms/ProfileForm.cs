using System;
using System.Drawing;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class ProfileForm : Form
    {
        private Container container;

        public ProfileForm(Container container)
        {
            InitializeComponent();
            this.container = container;

            // Preenche ComboBox de tema (caso não tenha feito no designer)
            cbThemeSelector.Items.Clear();
            cbThemeSelector.Items.AddRange(new string[] { "Dark", "Light Gray", "Light" });

            // Seleciona o tema atual
            cbThemeSelector.SelectedIndex = (int)ThemeManager.CurrentTheme;
            cbThemeSelector.SelectedIndexChanged += ThemeComboBox_SelectedIndexChanged;

            // Aplica tema ao abrir
            ThemeManager.ApplyThemeToForm(this);

            // Preenche a lista de perfis (sem o Default)
            lbProfilesList.Items.Clear();
            foreach (string profile in Profile.ListAll())
            {
                if (profile != "Default")
                {
                    lbProfilesList.Items.Add(profile);
                }
            }
        }

        private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeManager.ChangeTheme((AppTheme)cbThemeSelector.SelectedIndex);

            // Aplica o tema a todas as janelas abertas ao trocar o tema
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Container containerForm)
                {
                    // Usa o método especial para o Container que preserva cores dos botões
                    containerForm.ApplyThemeWithStatusColors();
                }
                else
                {
                    ThemeManager.ApplyThemeToForm(openForm);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newProfileName = txtProfileName.Text;
            if (string.IsNullOrEmpty(newProfileName)) { return; }

            ProfileSingleton.Create(newProfileName);
            lbProfilesList.Items.Add(newProfileName);
            container.refreshProfileList();
            txtProfileName.Text = ""; // Limpa o campo
        }

        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            if (lbProfilesList.SelectedItem == null)
            {
                MessageBox.Show("No profile found! To delete a profile, first select an option from the Profile list.");
                return;
            }

            string selectedProfile = lbProfilesList.SelectedItem.ToString();
            if (selectedProfile == "Default")
            {
                MessageBox.Show("Cannot delete a Default profile!");
            }
            else
            {
                ProfileSingleton.Delete(selectedProfile);
                lbProfilesList.Items.Remove(selectedProfile);
                container.refreshProfileList();
            }
        }

        private void cbThemeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gbTheme_Enter(object sender, EventArgs e)
        {

        }
    }
}