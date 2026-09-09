## Training a smart agent in Unity

Hi guys i just wanted to learn how to incorporate machine learning into my Unity projects. I watched [this tutorial](https://youtu.be/zPFU30tbyKs?si=8NQ2mQc9rcpiClnh) from Code Monkey but slightly modified it to work in 2026 since the vid is pretty old. My friends were interested in learning how to do this too so I'm writing this detailed readme for them but if you happen to stumble upon this I hope its somewhat useful or interesting.
<img width="800" height="450" alt="Untitleddesign2-ezgif com-video-to-gif-converter" src="https://github.com/user-attachments/assets/48411721-721a-4ee3-bb41-585eb5522fbc" />

### Set-up & install instructions
Ok so this is the [official doc](https://docs.unity3d.com/Packages/com.unity.ml-agents@4.0/manual/Installation.html) with all the install instructions but I did it slightly differently. I'll write down how I did it but please note I am using **Windows 11** and **Unity 6** so there may be variations across different OSs.

- First you wanna **install Python 3.10** (My first mistake was attempting using Python 3.14)
- Make a folder for your project. You'll build your Unity project here as well as set up a virtual environment
- cd to your folder and type **py -3.10 -m venv venv** to create your virtual environment
- activate with **venv\Scripts\activate**
- now that you're in the virtual environment, pip install in this order:

1. **pip install mlagents==1.1.0** 
2. **pip install "torch==2.2.2" --index-url https://download.pytorch.org/whl/cu121** 
3. **mlagents-learn --help**

To run and start training the agent type:

**mlagents-learn**

This should pop up. Press play in the editor to start training. 
<img width="850" height="330" alt="image" src="https://github.com/user-attachments/assets/a21e5aeb-e9dc-4177-9ced-b0904351e407" />

After running the first time you may notice an error preventing you from running again. In subsequent runs, type either:

- **mlagents-learn --run-id=[your choice]**
- **mlagents-learn --force**

I'm gonna assume you have Unity (6) installed and C# .NET stuff setup since this is a unity project afterall but if you don't here's some material:
- [Unity Manual](https://docs.unity3d.com/Manual/get-started.html)
- [C#/.NET download](https://dotnet.microsoft.com/en-us/download) (I also highly recommend getting the Unity add-ons for your IDE)
