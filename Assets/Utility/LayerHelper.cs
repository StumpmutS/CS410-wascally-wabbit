using UnityEngine;

namespace Utility
{
    public static class LayerHelper
    {
        public static bool LayerEqualsMask(int layer, LayerMask layerMask)
        {
            return (1 << layer & layerMask) != 0;
        }

        // Assumes mask contains only one layer
        public static int MaskToLayer(LayerMask mask)
        {
            if (mask == 0) return 0;
            
            for (int i = 0; i < 32; i++)
            {
                if (LayerEqualsMask(i, mask)) return i;
            }

            return -1;
        }
    }
}