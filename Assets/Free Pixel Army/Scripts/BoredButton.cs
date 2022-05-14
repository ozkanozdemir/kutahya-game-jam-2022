using UnityEngine;


public class BoredButton : MonoBehaviour
{
    public GameObject aristocrat,BGRBoy,BlueCapBoy,BlueHood,Builder,Businessman,BWMan,Chef,VGBoy,Cowboy,Cyborg,DressGirl1,DressGirl2,FEZ,GBMan,KarateBoy,NerdBoy,Whiskered,Frost,NerdGirl,Ninja,Oldster1,
        Oldster2,Pirate,Plumber,Punk,WhiteHood,RGBoy,Robot,Rogue,RYGirl,Scientist,Stanley,SunGirl,Thief,YBBoy;
    Animator anim, anim2,anim3,anim4, anim5, anim6, anim7, anim8, anim9, anim10, anim11, anim12, anim13, anim14, anim15, anim16, anim17, anim18, anim19, anim20, anim21, anim22, anim23,
        anim24, anim25, anim26, anim27, anim28, anim29, anim30, anim31, anim32, anim33, anim34, anim35, anim36;
    void Start()
    {
        anim = aristocrat.GetComponent<Animator>();
        anim2 = BGRBoy.GetComponent<Animator>();
        anim3 = BlueCapBoy.GetComponent<Animator>();
        anim4 = BlueHood.GetComponent<Animator>();
        anim5 = Builder.GetComponent<Animator>();
        anim6 =Businessman.GetComponent<Animator>();
        anim7 =BWMan.GetComponent<Animator>();
        anim8 =Chef.GetComponent<Animator>();
        anim9 =VGBoy.GetComponent<Animator>();
        anim10 =Cowboy.GetComponent<Animator>();
        anim11 = Cyborg.GetComponent<Animator>();
        anim12 = DressGirl1.GetComponent<Animator>();
        anim13 = DressGirl2.GetComponent<Animator>();
        anim14 = FEZ.GetComponent<Animator>();
        anim15 = GBMan.GetComponent<Animator>();
        anim16 = KarateBoy.GetComponent<Animator>();
        anim17 = NerdBoy.GetComponent<Animator>();
        anim18 = Whiskered.GetComponent<Animator>();
        anim19 = Frost.GetComponent<Animator>();
        anim20 = NerdGirl.GetComponent<Animator>();
        anim21 = Ninja.GetComponent<Animator>();
        anim22 = Oldster1.GetComponent<Animator>();
        anim23 = Oldster2.GetComponent<Animator>();
        anim24 = Pirate.GetComponent<Animator>();
        anim25 = Plumber.GetComponent<Animator>();
        anim26 = Punk.GetComponent<Animator>();
        anim27 = WhiteHood.GetComponent<Animator>();
        anim28 = RGBoy.GetComponent<Animator>();
        anim29 = Robot.GetComponent<Animator>();
        anim30 = Rogue.GetComponent<Animator>();
        anim31 = RYGirl.GetComponent<Animator>();
        anim32 = Scientist.GetComponent<Animator>();
        anim33 = Stanley.GetComponent<Animator>();
        anim34 = SunGirl.GetComponent<Animator>();
        anim35 = Thief.GetComponent<Animator>();
        anim36 = YBBoy.GetComponent<Animator>();

    }
    public void OnMouseUpAsButton()
    {
        anim.SetInteger("Animate", 3);
        anim2.SetInteger("Animate", 3);
        anim3.SetInteger("Animate", 3);
        anim4.SetInteger("Animate", 3);
        anim5.SetInteger("Animate", 3);
        anim6.SetInteger("Animate", 3);
        anim7.SetInteger("Animate", 3);
        anim8.SetInteger("Animate", 3);
        anim9.SetInteger("Animate", 3);
        anim10.SetInteger("Animate", 3);
        anim11.SetInteger("Animate", 3);
        anim12.SetInteger("Animate", 3);
        anim13.SetInteger("Animate", 3);
        anim14.SetInteger("Animate", 3);
        anim15.SetInteger("Animate", 3);
        anim16.SetInteger("Animate", 3);
        anim17.SetInteger("Animate", 3);
        anim18.SetInteger("Animate", 3);
        anim19.SetInteger("Animate", 3);
        anim20.SetInteger("Animate", 3);
        anim21.SetInteger("Animate", 3);
        anim22.SetInteger("Animate", 3);
        anim23.SetInteger("Animate", 3);
        anim24.SetInteger("Animate", 3);
        anim25.SetInteger("Animate", 3);
        anim26.SetInteger("Animate", 3);
        anim27.SetInteger("Animate", 3);
        anim28.SetInteger("Animate", 3);
        anim29.SetInteger("Animate", 3);
        anim30.SetInteger("Animate", 3);
        anim31.SetInteger("Animate", 3);
        anim32.SetInteger("Animate", 3);
        anim33.SetInteger("Animate", 3);
        anim34.SetInteger("Animate", 3);
        anim35.SetInteger("Animate", 3);
        anim36.SetInteger("Animate", 3);
    }
}
