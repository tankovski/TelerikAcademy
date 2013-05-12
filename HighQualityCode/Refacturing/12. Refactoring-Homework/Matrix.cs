using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Matrix
    {
        private int length;
        private int[,] body;

        public Matrix(int length)
        {
            this.Length = length;
            this.body = new int[this.Length,this.Length];
        }

        public int[,] Body
        {
            get
            {
                return this.body;
            }
            private set
            {
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value<0 || value>100)
                {
                    throw new ArgumentOutOfRangeException("Matrix length must be between 0 and 100");
                }
                this.length = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.body.GetLength(0); i++)
            {
                for (int j = 0; j < this.body.GetLength(1); j++)
                {
                    sb.Append(this.body[i, j]);

                    if (j<this.body.GetLength(1)-1)
                    {
                        sb.Append(" ");
                    }
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }

