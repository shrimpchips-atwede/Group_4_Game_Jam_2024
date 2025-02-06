// This code has been written by AHMET ALP for the Unity Asset "AA Save and Load System".
// Link to the asset store page: https://u3d.as/2TxY
// Publisher contact: ahmetalp.business@gmail.com

namespace AASave
{
    [System.Serializable]
    public class Vector2Block
    {
        public string dataName, value = "";

        public Vector2Block(string dataName, float valueX, float valueY, bool encryptData)
        {
            if (encryptData)
            {
                this.dataName = AAEncryption.Encrypt(dataName);

                value = "";
                value += valueX.ToString() + "#";
                value += valueY.ToString() + "#";
                value = AAEncryption.Encrypt(value);
            }
            else
            {
                this.dataName = dataName;

                value = "";
                value += valueX.ToString() + "#";
                value += valueY.ToString() + "#";
            }
        }
    }
}
