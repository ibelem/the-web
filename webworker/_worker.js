 function messageHandler(e) {
	//postMessage(e.data + ' 2012');
	
	var n = e.data;  // 获取数据作为参数
    var ret = fib(n);  // 计算
    postMessage(ret); // 将计算结果传递给UI线程
	
	
 }
 addEventListener('message', messageHandler, true);

 

// 递归实现的斐波那契数列计算函数
function fib (n) {
    if (n < 0) return -1; // 非法参数返回-1
    else if (n === 0 || n === 1) {
        return 1;
    } else {
        return fib(n - 2) + fib(n - 1);
    }
}

