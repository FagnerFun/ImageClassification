using Microsoft.ML.Data;
using TensorFlowImageClassificationAPI.ModelScore;

namespace TensorFlowImageClassificationAPI.ImageDataStructures
{
    public class ImageNetPrediction
    {
        [ColumnName(TFModelScorer.InceptionSettings.outputTensorName)]
        public float[] PredictedLabels;
    }
}
