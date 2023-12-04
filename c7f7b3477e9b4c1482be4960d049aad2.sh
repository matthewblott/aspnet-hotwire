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
ps 69076;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 69076 > /dev/null;
done;
for child in $(list_child_processes 69101);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/c7f7b3477e9b4c1482be4960d049aad2.sh;
