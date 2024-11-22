#include <iostream>
#include <cstring>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>


#define PORT 1200

using namespace std;

int main(){
    int server_fd, new_socket;
    struct sockaddr_in address;
    int addrlen = sizeof(address);
    char buffer[1024] = {0};

    if((server_fd = socket(AF_INET, SOCK_STREAM, 0),0)){
        cout << "Erro ao criar o socket";
        return -1;
    }
    address.sin_family = AF_INET;
    address.sin_addr.s_addr = INADDR_ANY;
    address.sin_port = htons(PORT);
    if(bind(server_fd, (struct sockaddr *)&address, sizeof(address)) < 0){
        cout << "Erro ao definir ao IP e Porta";
        return -1;
    }

    if(listen(server_fd, 3) < 0){
        cout << "erro ao esperar comunicação...";
        return -1;
    }
    std::cout << "Conexão iniciada em: " << PORT << endl;
    std::cout << "Aguardando conexao..." << endl;

    while(true){
        
    }

    return 0;
}