#include <iostream>
#include <SecretHackingSkills>
#include <Employees>

int main() {
    std::cout << "Initiate termination sequence [y/N]: ";
    char response = 'N';
    std::cin >> response;
    if( response != 'y' && response != 'Y' ) {
        return 2;
    }

    SecretHackingSkills::RobotKiller robotKiller( SecretHackingSkills::RobotKiller::NO_MERCY );

    Employees::iterator empIt = Employees.begin();
    while(empIt.next()) {
        if( (*(empIt.data()))->actingWeird ) {
            robotKiller->bufferOverflow( *empIt );
        }
    }

    std::cout << "It is done." << std::endl;
    return 0;
}
