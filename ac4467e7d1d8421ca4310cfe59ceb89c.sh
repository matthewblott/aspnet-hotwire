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
ps 63805;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 63805 > /dev/null;
done;
for child in $(list_child_processes 63822);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/ac4467e7d1d8421ca4310cfe59ceb89c.sh;
