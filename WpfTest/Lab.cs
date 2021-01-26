using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    class Lab
    {
        public string Name { get; set; }
        public List<Exercise> Graf { get; set; }
    }

    class Exercise
    {
        public string TrafficDescription { get; private set; }
        public string[] comment { get; private set; }
        public string formText { get; private set; }
        public List<double[]> param { get; private set; }
        public bool lens { get; private set; }

        public Exercise(string trafic, string[] comment, List<double[]> param, bool lens = true)
        {
            TrafficDescription = trafic;
            this.comment = comment;
            this.param = param;
            this.lens = lens;
        }

        public Exercise(string trafic, string formText)
        {
            TrafficDescription = trafic;
            this.formText = formText;
        }

        public Exercise(string trafic)
        {
            TrafficDescription = trafic;
        }
    }

    class CategoryLab
    {
        static public List<Lab> GetCreatorList()
        {
            Realization realization = new Realization();
            Lab Lab2 = new Lab();//+
            Lab2.Name = "Лабораторная 2";
            Lab2.Graf = new List<Exercise>()
            {
                new Exercise("2.1",
                new string[] {
                    "K = 0.5 T = 2.5",
                    "K = 1.5 T = 2.5",
                    "K = 0.5 T = 1.5"},
                new List<double[]>(){ 
                    realization.Realization2_1(0.5, 2.5), 
                    realization.Realization2_1(1.5, 2.5), 
                    realization.Realization2_1(0.5, 1.5) }
                ),
                new Exercise("2.2",
                new string[] {
                    "k = 4, T1 = 1, T1 = 4",
                    "k = 4, T1 = 1, T1 = 5",
                    "k = 5, T1 = 2, T1 = 3"},
                new List<double[]>(){
                    realization.Realization2_2(4, 1, 4),
                    realization.Realization2_2(4, 1, 5),
                    realization.Realization2_2(5, 1, 3) }
                ),
                new Exercise("2.3",
                new string[] {
                    "k1 = 0.5, k2 = 5, T1 = 2.5, T2 = 2, T3 = 3",
                    "k1 = 1.5, k2 = 7, T1 = 2.5, T2 = 2, T3 = 3",
                    "k1 = 0.5, k2 = 5, T1 = 1.5, T2 = 3, T3 = 2"},
                new List<double[]>(){
                    realization.Realization2_3(0.5, 5, 2.5, 2, 3),
                    realization.Realization2_3(2.5, 7, 2.5, 2, 3),
                    realization.Realization2_3(0.5, 5, 1.5, 3, 2)}
                )
            };
            
            Lab Lab3 = new Lab();
            Lab3.Name = "Лабораторная 3";
            Lab3.Graf = new List<Exercise>()
            {
                new Exercise("3.2",
                new string[] {
                    "АФЧХ при k = 2; T = 3",
                    "АФЧХ при k = 2; T = 4",
                    "АФЧХ при k = 4; T = 3"},
                new List<double[]>(){
                    realization.Realization3_2(2, 3),
                    realization.Realization3_2(2, 4),
                    realization.Realization3_2(4, 3)},
                false
                ),                 
                new Exercise("3.3",
                new string[] {
                    "АЧХ при k = 2; T = 3",
                    "АЧХ при k = 2; T = 4",
                    "АЧX при k = 4; T = 3"},
                new List<double[]>(){
                    realization.Realization3_3(2, 3),
                    realization.Realization3_3(2, 4),
                    realization.Realization3_3(4, 3)}
                ),
                new Exercise("3.4",
                new string[] {
                    "ФЧХ при k = 4; T = 6",
                    "АЧX при k = 2; T = 18"},
                new List<double[]>(){
                    realization.Realization3_4(4, 6),
                    realization.Realization3_4(2, 18)}
                ),
                new Exercise("3.5",
                new string[] {
                    "АФЧX при k = 2; T1 = 3; T2 = 5",
                    "АФЧX при k = 4; T1 = 3; T2 = 5",
                    "АФЧX при k = 2; T1 = 1; T2 = 2"},
                new List<double[]>(){
                    realization.Realization3_5(2, 3, 5),
                    realization.Realization3_5(4, 3, 5),
                    realization.Realization3_5(2, 1, 2)},
                false
                ), 
                new Exercise("3.6",
                new string[] {
                    "ФЧX при k = 2; T1 = 3; T2 = 5",
                    "ФЧX при k = 4; T1 = 5; T2 = 5"},
                new List<double[]>(){
                    realization.Realization3_6(2, 3, 5),
                    realization.Realization3_6(4, 5, 5)}
                ),
                new Exercise("3.7",
                new string[] {
                    "АЧX при k = 2; T1 = 2; T2 = 1",
                    "АЧX при k = 2; T1 = 3; T2 = 5",
                    "АЧX при k = 4; T1 = 3; T2 = 5"},
                new List<double[]>(){
                    realization.Realization3_7(2, 3, 1),
                    realization.Realization3_7(2, 3, 5),
                    realization.Realization3_7(4, 3, 5)}
                )
            };

            Lab Lab4 = new Lab();//+
            Lab4.Name = "Лабораторная 4";
            Lab4.Graf = new List<Exercise>()
            {
                new Exercise("4.1",
                realization.Realization4_1(new double[]{1, 2, 3, 4, 5, 6, 100, 0}) //5, 12, 20, 25, 15, 6, 1, 0
                ),
                new Exercise("4.2",
                realization.Realization4_2(new double[]{5, 20, 10, 25}) //5, 12, 20, 25, 15, 6, 1, 0
                ),
                new Exercise("4.3",
                new string[] {$"(0.005, 0.1, 2.5, 20, 50, 200) - {realization.Realization4_1(new double[] { 0.005, 0.1, 2.5, 20, 50, 200 })}"},
                new List<double[]>(){ realization.Realization4_3(new double[]{0.005, 0.1, 2.5, 20, 50, 200})},
                false
                )
            };

            Lab Lab5 = new Lab();//+
            Lab5.Name = "Лабораторная 5";
            Lab5.Graf = new List<Exercise>()
            {
                new Exercise("5.1",
                new string[] {
                    "K = 1.08 T = 0",
                    "K = 0.61 T = 0.089",
                    "K = 0 T = 0.047",
                    "K = 2.36 T = 0.35"
                },
                new List<double[]>(){ 
                    realization.Realization5_1(1.08, 0),
                    realization.Realization5_1(0.61, 0.089),
                    realization.Realization5_1(0, 0.047),
                    realization.Realization5_1(2.36, 0.35)
                },
                false
                )
            };

            return new List<Lab>() { Lab2, Lab3, Lab4, Lab5};
        }
    }
}
