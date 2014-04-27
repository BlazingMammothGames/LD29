#include <iostream>
#include <LoveAnSupport>
#include <eMail>

int main() {
    EMail eMail = new eMail( "Gwen", "The Office", "We're here for you!" );
    eMail.AddPicture( "cute_kitten.gif" );
    eMail.AddText( "Hang in there!" );
    eMail.AddText( "We'll catch you when you fall!" );
    eMail.AddHug();

    eMail.Send();
    std::cout << "eCard sent!" << std::endl;

    return 0;
}
