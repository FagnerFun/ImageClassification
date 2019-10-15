using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TensorFlowImageClassificationAPI.ModelScore;

namespace TensorFlowImageClassificationAPI.Service
{
    public class ImageClassification
    {
        public string Classificate()
        {
            string assetsRelativePath = @"../../../inputs";
            string assetsPath = GetAbsolutePath(assetsRelativePath);

            var tagsTsv = Path.Combine(assetsPath, "images", "tags.tsv");
            var imagesFolder = Path.Combine(assetsPath, "images");
            var inceptionPb = Path.Combine(assetsPath, "inception", "tensorflow_inception_graph.pb");
            var labelsTxt = Path.Combine(assetsPath, "inception", "imagenet_comp_graph_label_strings.txt");
            
            try
            {
                var modelScorer = new TFModelScorer(tagsTsv, imagesFolder, inceptionPb, labelsTxt);
                return modelScorer.Score();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}
