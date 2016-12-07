
namespace OpenResKit.Approval.Models
{
    public class Substance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public string DangerTypes { get; set; }
        public string Action { get; set; }
        public int RiskPotential { get; set; }

        internal RiskPotential RiskPotentialEnum
        {
            get { return (RiskPotential) RiskPotential; }
            set
            {
                if (RiskPotential != (int)value)
                {
                    RiskPotential = (int)value;
                }
            }
        }

        internal Type TypeEnum
        {
            get { return (Type) Type; }
            set
            {
                if (Type != (int)value)
                {
                    Type = (int)value;
                }
            }
        }

        internal Category CategoryEnum
        {
            get { return (Category) Category; }
            set
            {
                if (Category != (int)value)
                {
                    Category = (int)value;
                }
            }
        }
    }
}
