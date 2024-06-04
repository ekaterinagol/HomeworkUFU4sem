using PhotoEnhancer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class RangeUpperParameters : IParameters
    {
        public double Upper { get; set; } = 1.0;
        public double Lower { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name ="Верхний порог",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 1,
                    Increment=0.01,
                },
                new ParameterInfo()
                {
                    Name ="Нижний порог",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0,
                    Increment=0.01,
                }
            };
        }

        public void SetValues(double[] values)
        {
            Upper = values[0];
            Lower = values[1];

        }
    }
}
