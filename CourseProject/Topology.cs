using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class Topology
    {
        public int InputCount { get; }//колл-во входных нейронов(первый слой)
        public int OutputCount { get; }//колл-во выходных нейронов(последний слой)
        public double LearningRate { get; } 
        public List<int> HiddenLayers { get; }

        public Topology(int inputCount, int outputCount,double learningRate, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            LearningRate = learningRate;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
        }
    }
}
