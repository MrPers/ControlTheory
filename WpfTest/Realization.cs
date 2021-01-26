using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WpfTest
{
    public class Realization
    {
        double Fa(double Ka, double Ta, double dt, double x, double y) => (1.0 - dt / Ta) * y + dt / Ta * x * Ka;
        double Fi(double Ki, double dt, double x, double y) => (dt * Ki * x) + y;
        double Fp(double Kp, double x) => (Kp * x);

        public double[] Realization2_1(double k, double T)
        {
            double[] A = new double[100];

            for (int i = 0; i < A.Length; i++)
                A[i] = (k / T) * Math.Pow(Math.E, -(i / 10.0 / T));

            return A;
        }
        public double[] Realization2_2(double k, double T1, double T2)
        {
            double[] h = new double[200];

            for (int I = 0; I < h.Length; I++)
                h[I] = k * (1 + (T1 / (T2 - T1)) * Math.Pow(Math.E, -(I / 10.0 / T1)) + (T2 / (T1 - T2)) * Math.Pow(Math.E, -(I / 10.0 / T2)));

            return h;
        }
        public double[] Realization2_3(double k1, double k2, double T1, double T2, double T3)
        {
            double[] h = new double[200];

            for (int I = 0; I < h.Length; I++)
                h[I] = ((k1 * k2 * T2 * Math.Abs(T2 * (T3 - T1) - Math.Pow(T3, 2) * (T2 - T1))) * Math.Exp(-(I / 10.0 / T1)) / ((T3 - T2) * (T3 - T1) * (T2 - T1) * T1))

                     - ((k1 * k2 * T1 * T2) * Math.Exp(-(I / 10.0 / T2)) / ((T3 - T2) * (T2 - T1))) + ((k1 * k2 * T1 * T2 * T3) * Math.Exp(-(I / 10.0 / T3)) / ((T3 - T2) * (T3 - T1)));
            return h;
        }
        public double[] Realization3_2(double k, double T)
        {
            double[] K = new double[4000];

            for (int I = 0; I < K.Length/2; I++)
            {
                K[I] = (k * I / 100.0) / (1 + (T * T * I / 100.0 * I / 100.0));
                K[I + K.Length / 2] = (k * I / 100.0 * I / 100.0 * T) / (1 + (T * T * I / 1000.0 * I / 10.0));
            }

            return K;
        }
        public double[] Realization3_3(double k, double T)
        {
            double[] K = new double[50];

            for (int I = 0; I < K.Length; I++)
                K[I] = (k * I / 100.0) / Math.Sqrt(1 + T * T * (I / 100.0) * (I / 100.0));

            return K;
        }
        public double[] Realization3_4(double k, double T)
        {
            double[] K = new double[50];

            for (int I = 0; I < K.Length; I++)
                K[I] = Math.Atan(((1) / (T * I)) * 180 / Math.PI);

            return K;
        }
        public double[] Realization3_5(double k, double T1, double T2)
        {
            double[] K = new double[1000];

            for (int I = 0; I < K.Length/2; I++)
            {
                K[I] = -(k * (double)(I / 100.0) * (T1 + T2)) / ((1 + T1 * T1 * (double)(I / 100.0) * (double)(I / 100.0)) * (1 + T2 * T2 * (double)(I / 100.0) * (double)(I / 100.0)));
                K[I + K.Length / 2] = (k * (1 - (double)(I / 100.0) * (double)(I / 100.0) * T1 * T2)) / ((1 + T1 * T1 * (double)(I / 100.0) * (double)(I / 100.0)) * (1 + T2 * T2 * (double)(I / 100.0) * (double)(I / 100.0)));
            }

            return K;
        }
        public double[] Realization3_6(double k, double T1, double T2)
        {
            double[] K = new double[70];

            for (int I = 0; I < K.Length; I++)
                K[I] = Math.Atan((((-I / 10.0) * (T1 + T2)) / (1 - (T1 * T2 * Math.Pow((I / 10.0), 2)))) * 180 / Math.PI);

            return K;
        }
        public double[] Realization3_7(double k, double T1, double T2)
        {
            double[] K = new double[70];

            for (int I = 0; I < K.Length; I++)
                K[I] = (k) / Math.Sqrt(1 + Math.Pow(T1, 2) * Math.Pow(I / 10.0, 2) * Math.Pow(T2, 2) * Math.Pow(I / 10.0, 2));

            return K;
        }
        public string Realization4_1(double[] a)
        {
            string K = "устойчивая";
            double[,] arr = new double[a.Length, a.Length / 2];
            double[] r = new double[a.Length / 2 + 1];
            int time = 0;

            for (int t = 0; t < a.Length; t = t + 2)
            {
                arr[0, time] = a[t];
                arr[1, time] = a[1 + t];
                time++;
            }

            for (int i = 0; i < a.Length / 2; i++)
            {
                r[i] = Math.Round(arr[i, 0] / arr[i + 1, 0], 2);
                for (int t = 0; t < a.Length / 2 - 1; t++)
                    arr[i + 2, t] = arr[i, t + 1] - Math.Round(r[i] * arr[i + 1, t + 1], 2);
            }
            r[a.Length / 2] = Math.Round(arr[a.Length / 2, 0] / arr[a.Length / 2 + 1, 0], 2);

            foreach (var item in r)
                if (item < 0) K = "не устойчивая";

            return K;
        }
        public string Realization4_2(double[] a)
        {
            string K = "устойчивая";

            if ((a[1] * a[2]) - (a[0] * a[3]) < 0) K = "не устойчивая";

            return K;
        }
        public double[] Realization4_3(double[] a)
        {
            double[] A = new double[200];

            for (int i = 0; i < 100; i++)
            {
                double w = i * 0.2;
                A[i + A.Length / 2] = 58 - 0.58 * w * w;
                A[i] = w - 5.7e-3 * w * w * w; //e-3 = (10 в -3)
            }
            return A;
        }
        public double[] Realization5_1(double Kp, double Ki)
        {
            double[] Kek = new double[30000];
            double[] K = new double[3] { 1.5, 1, 1 };

         double[] Ta = new double[3] { 5, 4, 4 };
            double[] y = new double[3] { 0, 0, 0 };
            double[] Y = new double[3] { 1, 1, 1 };
            double mu, x0 = 0, mu0 = 0, E0 = 0, i0 = 0, t = 150, dt = 0.01;
            double N = t / dt;
            double Gmax = 0.1 * 470.1;

            for (int I = 0; I < N; I++)
            {
                int i;
                double x = mu0 + Gmax;
                Y[0] = Fa(K[0], Ta[0], dt, x0, y[0]);
                Y[1] = Fa(K[1], Ta[1], dt, y[0], y[1]);
                Y[2] = Fa(K[2], Ta[2], dt, y[1], y[2]);
                double E = -y[2];
                double j = Fi(Ki, dt, E0, i0);
                mu = Fp(Kp, E0) + j;
                Kek[I + (int)(t / dt)] = dt * I;
                Kek[I] = Y[2];
                for (i = 0; i < y.Length; i++)
                    y[i] = Y[i];
                E0 = E;
                i0 = j;
                mu0 = mu;
                x0 = x;
            }

            return Kek;
        }
    }
}
