function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}
ps 62708;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 62708 > /dev/null;
done;
for child in $(list_child_processes 62729);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/b0caa5b8920e4209a7bc6030b56844f8.sh;
