#include "iostream"
#include "LoginUser.h"

using namespace std;

int main() {
	LoginUser loginUser;
	printf("�������û�����");
	scanf("%s", &loginUser.Account);
	if (loginUser.Account == NULL) {
		printf("�û�������Ϊ�գ�");
		system("pause");
		return 0;
	}
	printf("��������ǣ�\n");
	printf("%s\n", &loginUser.Account);
	char *p1 = &loginUser.Account;
	char **p2 = &p1;
	cout << "&Account=" << &loginUser.Account << endl;
	cout << "Account=" << loginUser.Account << endl;
	cout << "p1=" << p1 << endl;
	cout << "&p1=" << &p1 << endl;
	cout << "*p1=" << *p1 << endl;
	cout << "p2=" << p2 << endl;
	cout << "&p2=" << &p2 << endl;
	cout << "*p2=" << *p2 << endl;
	cout << "*p2=" << **p2 << endl;
	system("pause");
	return 0;
}