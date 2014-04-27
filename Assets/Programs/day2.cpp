#include <iostream>
#include <SecretHackingSkills>

int main() {
	SecretHackingSkills *skillz = new SecretHackingSkills("#@&*!", 42, "www.enesseh.com");
	if( !skillz->testFlargle() )
		std::cout << "You failed the flargle" << std::endl;
	if( !skillz->testDarbak() )
		std::cout << "L2DARBAK" << std::endl;
	if( !skillz->goPatoosh() )
		std::cout << "Shoot, can't patoosh!" << std::endl;
	return 42;
}