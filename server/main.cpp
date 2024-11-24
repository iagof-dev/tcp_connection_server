#include <iostream>
#include <cstring>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>

#define ADDRESS "0.0.0.0"
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
    cout << "Conexão iniciada em: " << PORT << endl;
    cout << "Aguardando conexao..." << endl;

    while(true){
        new_socket = accept(server_fd, (struct sockaddr *)&address, (socklen_t *)&addrlen);
        if (new_socket < 0) {
            cerr << "Erro ao aceitar conexão: " << strerror(errno) << endl;
            continue;
        }
        cout << "Nova conexão estabelecida!" << endl;
        int valread = read(new_socket, buffer, sizeof(buffer) - 1);
        if (valread > 0) {
            buffer[valread] = '\0'; // Garantir que o buffer seja uma string válida
            cout << "Mensagem recebida: " << buffer << endl;
            string resposta = "Mensagem recebida com sucesso!";
            send(new_socket, resposta.c_str(), resposta.length(), 0);
        } else {
            cerr << "Erro ao ler mensagem: " << strerror(errno) << endl;
        }
        memset(buffer, 0, sizeof(buffer));
        close(new_socket);
    }

    return 0;
}