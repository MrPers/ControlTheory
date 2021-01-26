using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using OxyPlot;
using OxyPlot.Series;


namespace MainModel
{
    public class MainViewModel
    {

        public MainViewModel(string name, string[] arrComment, List<double[]> arrParam, bool lens)
        {
            MyModel = new PlotModel { Title = name };
            List<LineSeries> lines = new List<LineSeries>();

            for (int i = 0; i < arrComment.Length; i++)
            {
                lines.Add(new LineSeries { Title = arrComment[i] });
                MyModel.Series.Add(lines[i]);

                if (lens)
                    for (int time = 0; time < arrParam[arrParam.Count - 1].Length; time++)
                        lines[i].Points.Add(new DataPoint((double)(time / 10.0), arrParam[i][time]));
                else
                    for (int time = 0; time < arrParam[arrParam.Count - 1].Length / 2; time++)
                        lines[i].Points.Add(new DataPoint(arrParam[i][arrParam[arrParam.Count - 1].Length / 2 + time], arrParam[i][time]));
            }

        }

        public PlotModel MyModel { get; private set; }
    }
}
