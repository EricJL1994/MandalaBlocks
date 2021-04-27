using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonFIleInterface
{
    //Boulder b = new Boulder(AssetsLibrary.Instance.GetBoulderDifficulty("Green"), 1, 0);
    //Traverse t = new Traverse(AssetsLibrary.Instance.GetTraverseDifficulty("Violet"), 1, new List<BoulderWall>() { 0 });

    public static void ReadAllFiles()
    {
        foreach (DirectoryInfo dirInfo in new DirectoryInfo(Application.persistentDataPath).GetDirectories())
        {
            Type dirType = Type.GetType(dirInfo.Name);

            if (!typeof(Problem).IsAssignableFrom(dirType)) continue;

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string json = File.ReadAllText(file.FullName);
                object o = Activator.CreateInstance(type: dirType, args: new object[] { json });

                /*
                o as Boulder;
                Debug.Log(o.GetType());
                */


                if (o is Boulder b) BoulderListController.Instance.CreateBoulderDisplay(b);
                if (o is Traverse t) TraverseListController.Instance.CreateTraverseDisplay(t);
            }
        }
    }

    /*private static void StoreBoulder(Boulder boulder)
    {
        if (!new DirectoryInfo(Application.persistentDataPath + "/" + boulder.GetType().Name).Exists)
            Directory.CreateDirectory(Application.persistentDataPath + "/" + boulder.GetType().Name);

        File.WriteAllText(Application.persistentDataPath + "/" + boulder.GetFileName(), boulder.Serialize());
    }

    private static void StoreTraverse(Traverse traverse)
    {
        if (!new DirectoryInfo(Application.persistentDataPath + "/" + traverse.GetType().Name).Exists)
            Directory.CreateDirectory(Application.persistentDataPath + "/" + traverse.GetType().Name);

        File.WriteAllText(Application.persistentDataPath + "/" + traverse.GetFileName(), traverse.Serialize());
    }*/

    public static void StoreProblem(Problem problem)
    {
        if (!new DirectoryInfo(Application.persistentDataPath + "/" + problem.GetType().Name).Exists)
            Directory.CreateDirectory(Application.persistentDataPath + "/" + problem.GetType().Name);

        File.WriteAllText(Application.persistentDataPath + "/" + problem.GetFileName(), problem.Serialize());
    }
}
