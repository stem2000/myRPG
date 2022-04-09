using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
public static class RandomGenerator
{
    public static int GenerateProbability(){
        int probability = 0;
        byte[] temp = {0};
        using(RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider()){
            provider.GetBytes(temp);
            if(temp[0] > 100 && temp[0] < 200)
                probability = temp[0] - 100;
            else if(temp[0] > 200)
                probability = temp[0] - 200;
            else probability = temp[0];}
        return probability;}
}
