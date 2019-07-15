using Constants;
using UnityEngine;

namespace Helpers {
    /**
     * This class is used to add noise to visual elements
     */
    public static class Noisifier {
        /**
         * This method adds noise to each vectors of a list
         */
        public static Vector3[] NoisifySmoothVectors(Vector3[] vectors, int numberOfVectorsWithSameNoiseInARow) {
            Vector3[] noisifiedVectors = new Vector3[vectors.Length];
            Vector2 noise = Random.insideUnitCircle * FriendZonesConstants.MaxLineNoiseAmplitude;
            for (int i = 0; i < vectors.Length; i++) {
                if (i % numberOfVectorsWithSameNoiseInARow == 0)
                    noise = Random.insideUnitCircle * FriendZonesConstants.MaxLineNoiseAmplitude;
                noisifiedVectors[i] = new Vector3(vectors[i].x + noise.x, vectors[i].y + noise.y, vectors[i].z);
            }
            return noisifiedVectors;
        }
    }
}