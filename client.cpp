#include <iostream>
#include <cstring>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <unistd.h>

#define ADDRESS "127.0.0.1"  
#define PORT 1200

using namespace std;

int main() {
    int sock = 0;
    struct sockaddr_in serv_addr;
    char buffer[1024] = {0};
    
    if ((sock = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
        cout << "Erro ao criar o socket" << endl;
        return -1;
    }
    
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_port = htons(PORT);
    
    if(inet_pton(AF_INET, ADDRESS, &serv_addr.sin_addr) <= 0) {
        cout << "erro no endereco" << endl;
        return -1;
    }
    
    if (connect(sock, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0) {
        cout << "conexao fechada ou invalida" << endl;
        return -1;
    }
    
    cout << "conectado no servidor com sucesso" << endl;
    
    while(true) {
        string mensagem;
        cout << "mensagem:  ";
        getline(cin, mensagem);
        
        if(mensagem == "sair") {
            break;
        }
        
        send(sock, mensagem.c_str(), mensagem.length(), 0);
        cout << "Enviada!" << endl;
        
        int valread = read(sock, buffer, 1024);
        cout << "Servidor: " << buffer << endl;
        
        memset(buffer, 0, sizeof(buffer));
    }
    
    close(sock);
    cout << "conexao fechada" << endl;
    
    return 0;
}