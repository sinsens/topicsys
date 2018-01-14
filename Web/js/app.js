/*
校园水电管理系统
@date:2017年11月26日
@author:sinsen
*/
function isIE() {
    //判断是否为IE
    //fork form http://www.jb51.net/article/76296.htm
    if (!!window.ActiveXObject || "ActiveXObject" in window)
        return true;
    else
        return false;
}

Date.prototype.Format = function (fmt) {
    //author: meizz,sinsen
    // fork from http://www.cnblogs.com/zhangpengshou/archive/2012/07/19/2599053.html
    var w = {
        1: "一",
        2: "二",
        3: "三",
        4: "四",
        5: "五",
        6: "六",
        7: "天",
        0: "天"
    }; // 把星期几转换成中文,sinsen
    var o = {
        "M+": this.getMonth() + 1, //月份
        "d+": this.getDate(), //日
        "w+": w[this.getDay()], //周
        "h+": this.getHours(), //小时
        "m+": this.getMinutes(), //分
        "s+": this.getSeconds(), //秒
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度
        "S": this.getMilliseconds() //毫秒
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};
(function ($, owner) {
    /* 登录判断 */

    /* 获取页面参数 */
    owner.getUrlParam = function (key) {
        var reg = new RegExp(key + '=([^&]*)');
        var results = location.href.match(reg);
        return results ? decodeURI(results[1]) : null;
    }
}(mui, window.app = {}));