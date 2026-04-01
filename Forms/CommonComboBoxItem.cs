using _4RTools.Model;

namespace _4RTools.Forms
{
    internal class ComboBoxItem
    {
        public string DisplayText { get; set; }
        public Buff Skill { get; set; }
        public bool IsHeader { get; set; }

        internal ComboBoxItem(string displayText, Buff skill, bool isHeader)
        {
            DisplayText = displayText;
            Skill = skill;
            IsHeader = isHeader;
        }

        public override string ToString() => DisplayText;
    }
}