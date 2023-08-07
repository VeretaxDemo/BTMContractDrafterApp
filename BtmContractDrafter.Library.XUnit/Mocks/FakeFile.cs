﻿namespace BtmContractDrafter.Library.XUnit.Mocks;

public class FakeFile
{
    public string Path { get; }
    public string TextContents { get; }

    public FakeFile(string path, string textContents)
    {
        Path = path;
        TextContents = textContents;
    }
}