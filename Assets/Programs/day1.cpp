#include <iostream>

int main() {
    for(unsigned int i = 99; i > 0; --i) {
        std::cout << i << " bottles of beer on the wall, " << i << " bottles of beer." << std::endl;
        std::cout << "Take one down, pass it around, " << (i - 1) << " bottles of beer on the wall..." << std::endl << std::endl;
    }

    return 0;
}