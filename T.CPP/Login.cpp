#include "iostream"
#include "LoginUser.h"

using namespace std;

int main() {
	LoginUser loginUser;
	printf("请输入用户名：");
	scanf("%s", &loginUser.Account);
	if (loginUser.Account == NULL) {
		printf("用户名不能为空！");
		system("pause");
		return 0;
	}
	printf("您输入的是：\n");
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