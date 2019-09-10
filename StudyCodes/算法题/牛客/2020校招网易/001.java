/*
 *  如果把一个数的各位数字反向排列所得数和原数一样，则这个数为回文数，给定一个十进制的正整数，再判断X在二进制下（去掉前导0）是否是回文数，如11的二进制位1011
 * 
 * 输入描述：
 * 输入第一行是一个正整数T（0 < T <= 100）, 表示有T组测试数据，对于每一个测试数据包含一个正整数X（0<X<=10000000)
 * 
 * 输出描述：
 * 对于每一组测试样例，如果X在二进制下是回文数则输出YES、否则输出NO
 * 
 * 3
 * 1
 * 4
 * 7
 * 
 * YES
 * NO
 * YES
 */
import java.util.Scanner;
public class Main
{
	public static void main(String[] args)
	{
		int N;
		Scanner scanner = new Scanner(System.in);
		N = scanner.nextInt();
		for (int i = 0; i < N; i++)
		{
			int x = scanner.nextInt();
			String str=Integer.toBinaryString(x);
			if ( new StringBuilder(str).reverse().toString().equals(str) )
			{
				System.out.println("YES");
			}
			else
			{
				System.out.println("NO");
			}
		}
	}
}
