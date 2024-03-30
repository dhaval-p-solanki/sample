namespace sampleApp;

public class SampleSealedClass
{


}


public sealed class SampleSealedClassBase
{
    private object _objConfig = new object(); 
    public object MyConfig { get _objConfig; set;}
    private SampleSealedClassBase(object objConfig)
    {
        this._objConfig = objConfig;
    }
    public SampleSealedClassBase()
    {
        
    }


}


public class SampleSealedClassChild : SampleSealedClassBase
{


}